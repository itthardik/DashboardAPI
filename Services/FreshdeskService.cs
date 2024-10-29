using Dashboard.Models.Dashboard.Models;
using Dashboard.Services.Interfaces;
using Dashboard.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;

namespace Dashboard.Services
{
    /// <summary>
    /// Freshdesk Repo
    /// </summary>
    /// <param name="httpClient"></param>
    public class FreshdeskService(HttpClient httpClient) : IFreshdeskService
    {
        private readonly HttpClient _httpClient = httpClient;


        /// <summary>
        /// Get all tickets
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetAllTickets(int pageNumber, int pageSize, string orderBy, string orderType)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"tickets?page={pageNumber}&per_page={pageSize}&order_by={orderBy}&order_type={orderType}");

            string responseData = await response.Content.ReadAsStringAsync();
            bool isNextPage = response.Headers.Contains("Link");

            if (!response.IsSuccessStatusCode)
                throw new CustomException(responseData, (int)response.StatusCode);

            return new JsonResult(new { data = JsonNode.Parse(responseData), isNextPage });

        }

        /// <summary>
        /// Get Tickets By Query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<JsonResult> GetTicketsByQuery(string query)
        {

            if (string.IsNullOrEmpty(query))
                throw new CustomException("Invalid Query", 400);

            HttpResponseMessage response = await _httpClient.GetAsync($"search/tickets?query=\"{query}\"");

            string responseData = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new CustomException(responseData, (int)response.StatusCode);

            return new JsonResult(JsonNode.Parse(responseData));

        }
        /// <summary>
        /// Get ticket by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<JsonResult> GetTicketById(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"tickets/{id}?include=stats");

            string responseData = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new CustomException(responseData, (int)response.StatusCode);

            return new JsonResult(new { data = JsonNode.Parse(responseData) });

        }

        /// <summary>
        /// Get Overall Stats
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<JsonResult> GetOverallStats()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"tickets?include=stats");

            string responseData = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new CustomException(responseData, (int)response.StatusCode);

            var tickets = JsonConvert.DeserializeObject<List<Ticket>>(responseData);


            int openCount = 0;
            int closedCount = 0;
            int unassignedCount = 0;
            TimeSpan totalResponseTime = TimeSpan.Zero;
            int responseTimeCount = 0;
            TimeSpan totalResolutionTime = TimeSpan.Zero;
            int resolutionTimeCount = 0;

            int lowPriorityOpenCount = 0;
            int mediumPriorityOpenCount = 0;
            int highPriorityOpenCount = 0;
            int urgentPriorityOpenCount = 0;

            int positiveFeedbackCount = 0;
            int neutralFeedbackCount = 0;
            int negativeFeedbackCount = 0;

            int feedbackCount;

            foreach (var ticket in tickets!)
            {

                if (ticket.Status == 5)
                {
                    closedCount++;
                }
                else
                {
                    openCount++;
                    switch (ticket.Priority)
                    {
                        case 1:
                            lowPriorityOpenCount++;
                            break;
                        case 2:
                            mediumPriorityOpenCount++;
                            break;
                        case 3:
                            highPriorityOpenCount++;
                            break;
                        case 4:
                            urgentPriorityOpenCount++;
                            break;
                    }
                }

                if (ticket?.ResponderId == null)
                {
                    unassignedCount++;
                }

                if (ticket?.Stats?.FirstRespondedAt != null && ticket.CreatedAt != null)
                {

                    if (DateTime.TryParse(ticket.CreatedAt, out DateTime createdAt) &&
                        DateTime.TryParse(ticket.Stats.FirstRespondedAt, out DateTime firstRespondedAt))
                    {
                        var responseTime = firstRespondedAt - createdAt;

                        totalResponseTime += responseTime;
                        responseTimeCount++;
                    }
                }
                if (ticket?.Stats?.ResolvedAt != null && ticket.CreatedAt != null)
                {
                    if (DateTime.TryParse(ticket.CreatedAt, out DateTime createdAt) &&
                        DateTime.TryParse(ticket.Stats.ResolvedAt, out DateTime resolvedAt))
                    {
                        var resolutionTime = resolvedAt - createdAt;

                        totalResolutionTime += resolutionTime;
                        resolutionTimeCount++;
                    }
                }
                if (ticket?.SentimentScore != null)
                {
                    if (ticket.SentimentScore >= 70)
                    {
                        positiveFeedbackCount++;
                    }
                    else if (ticket.SentimentScore <= 30)
                    {
                        negativeFeedbackCount++;
                    }
                    else
                    {
                        neutralFeedbackCount++;
                    }
                }
            }

            TimeSpan averageResponseTime = responseTimeCount > 0
                ? TimeSpan.FromMilliseconds(totalResponseTime.TotalMilliseconds / responseTimeCount)
                : TimeSpan.Zero;

            TimeSpan averageResolutionTime = resolutionTimeCount > 0
               ? TimeSpan.FromMilliseconds(totalResolutionTime.TotalMilliseconds / resolutionTimeCount)
               : TimeSpan.Zero;

            feedbackCount = positiveFeedbackCount + negativeFeedbackCount + neutralFeedbackCount;

            return new JsonResult(new
            {
                openTickets = openCount,
                closedTickets = closedCount,
                unassignedTickets = unassignedCount,
                priorityCounts = new
                {
                    lowPriorityOpenCount,
                    mediumPriorityOpenCount,
                    highPriorityOpenCount,
                    urgentPriorityOpenCount
                },
                feedbackCategories = new
                {
                    positiveFeedbackPercentage = feedbackCount > 0 ? Math.Floor((double)positiveFeedbackCount / feedbackCount * 100) : 0,
                    neutralFeedbackPercentage = feedbackCount > 0 ? Math.Floor((double)neutralFeedbackCount / feedbackCount * 100) : 0,
                    negativeFeedbackPercentage = feedbackCount > 0 ? Math.Floor((double)negativeFeedbackCount / feedbackCount * 100) : 0
                },
                averageResponseTime = new
                {
                    averageResponseTime.Hours,
                    averageResponseTime.Minutes,
                    averageResponseTime.Seconds
                },
                averageResolutionTime = new
                {
                    averageResolutionTime.Days,
                    averageResolutionTime.Hours,
                    averageResolutionTime.Minutes,
                    averageResolutionTime.Seconds
                }
            })
            { StatusCode = (int)HttpStatusCode.OK };
        }

        /// <summary>
        /// Add batch tickets
        /// </summary>
        /// <returns></returns>
        public async Task AddMultipleTickets()
        {

            List<object> tickets1 =
[
    new
    {
        description = "Issue with product delivery delay",
        subject = "Delivery delay concern",
        email = "alex.brown@example.com",
        priority = 2, // Medium priority
        status = 3,   // Pending status
        cc_emails = new List<string> { "logistics@example.com", "support@example.com" }
    },
    new
    {
        description = "Product color not as advertised",
        subject = "Product color discrepancy",
        email = "sarah.connor@example.com",
        priority = 1, // Low priority
        status = 2,   // Open status
        cc_emails = new List<string> { "quality@example.com" }
    },
    new
    {
        description = "Cannot apply discount code",
        subject = "Discount code application issue",
        email = "chris.evans@example.com",
        priority = 3, // High priority
        status = 2,   // Open status
        cc_emails = new List<string> { "sales@example.com", "support@example.com" }
    },
    new
    {
        description = "Received defective product",
        subject = "Defective product replacement",
        email = "emma.watson@example.com",
        priority = 4, // Urgent priority
        status = 1,   // Resolved status
        cc_emails = new List<string> { "returns@example.com", "quality@example.com" }
    },
    new
    {
        description = "Request to update account email",
        subject = "Account email update",
        email = "james.bond@example.com",
        priority = 1, // Low priority
        status = 2,   // Open status
        cc_emails = new List<string> { "techsupport@example.com" }
    },
    new
    {
        description = "Problem with refund processing",
        subject = "Refund processing assistance",
        email = "lucy.hale@example.com",
        priority = 3, // High priority
        status = 3,   // Pending status
        cc_emails = new List<string> { "finance@example.com", "support_lead@example.com" }
    },
    new
    {
        description = "Discount not applied at checkout",
        subject = "Checkout discount issue",
        email = "robert.pattinson@example.com",
        priority = 2, // Medium priority
        status = 2,   // Open status
        cc_emails = new List<string> { "sales@example.com" }
    },
    new
    {
        description = "Request for product exchange",
        subject = "Product exchange request",
        email = "natalie.portman@example.com",
        priority = 4, // Urgent priority
        status = 1,   // Resolved status
        cc_emails = new List<string> { "returns@example.com" }
    },
    new
    {
        description = "Billing discrepancy on last order",
        subject = "Billing issue resolution",
        email = "hugh.jackman@example.com",
        priority = 3, // High priority
        status = 2,   // Open status
        cc_emails = new List<string> { "finance@example.com" }
    },
    new
    {
        description = "Trouble navigating mobile site",
        subject = "Mobile site usability feedback",
        email = "anna.kendrick@example.com",
        priority = 1, // Low priority
        status = 2,   // Open status
        cc_emails = new List<string> { "ux@example.com" }
    },
    new
    {
        description = "Question regarding bulk order discount",
        subject = "Bulk order discount inquiry",
        email = "leonardo.dicaprio@example.com",
        priority = 2, // Medium priority
        status = 3,   // Pending status
        cc_emails = new List<string> { "sales@example.com" }
    },
    new
    {
        description = "Delay in response from customer support",
        subject = "Customer support response delay",
        email = "julia.roberts@example.com",
        priority = 3, // High priority
        status = 3,   // Pending status
        cc_emails = new List<string> { "support_lead@example.com" }
    },
    new
    {
        description = "Damaged item received in last order",
        subject = "Damaged item report",
        email = "will.smith@example.com",
        priority = 4, // Urgent priority
        status = 1,   // Resolved status
        cc_emails = new List<string> { "quality@example.com", "returns@example.com" }
    },
    new
    {
        description = "Unable to reset account password",
        subject = "Password reset issue",
        email = "scarlett.johansson@example.com",
        priority = 2, // Medium priority
        status = 2,   // Open status
        cc_emails = new List<string> { "techsupport@example.com" }
    },
    new
    {
        description = "Query about loyalty program benefits",
        subject = "Loyalty program details",
        email = "morgan.freeman@example.com",
        priority = 1, // Low priority
        status = 2,   // Open status
        cc_emails = new List<string> { "customerloyalty@example.com" }
    },
    new
    {
        description = "Refund not credited for returned item",
        subject = "Refund status inquiry",
        email = "matt.damon@example.com",
        priority = 3, // High priority
        status = 3,   // Pending status
        cc_emails = new List<string> { "finance@example.com" }
    },
    new
    {
        description = "Trouble with app performance on iOS",
        subject = "iOS app performance issue",
        email = "emma.stone@example.com",
        priority = 2, // Medium priority
        status = 2,   // Open status
        cc_emails = new List<string> { "mobiledev@example.com" }
    },
    new
    {
        description = "Incorrect item received in order",
        subject = "Incorrect item received",
        email = "benedict.cumberbatch@example.com",
        priority = 4, // Urgent priority
        status = 1,   // Resolved status
        cc_emails = new List<string> { "returns@example.com" }
    },
    new
    {
        description = "Request for invoice correction",
        subject = "Invoice correction request",
        email = "amy.adams@example.com",
        priority = 3, // High priority
        status = 2,   // Open status
        cc_emails = new List<string> { "finance@example.com" }
    },
    new
    {
        description = "Unable to track order shipment",
        subject = "Order tracking issue",
        email = "dwayne.johnson@example.com",
        priority = 2, // Medium priority
        status = 3,   // Pending status
        cc_emails = new List<string> { "logistics@example.com" }
    }
];


            foreach (var ticket in tickets1)
            {
                var jsonTicket = JsonConvert.SerializeObject(ticket);
                var content = new StringContent(jsonTicket, Encoding.UTF8, "application/json");

                await _httpClient.PostAsync("tickets", content);

            }

        }
    }

}
