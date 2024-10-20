using Dashboard.Models.Dashboard.Models;
using Dashboard.Services.Interfaces;
using Dashboard.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            Console.WriteLine($"search/tickets?query=\"{query}\"");

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
            { StatusCode = 200 };
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
                    description = "Issue with product not functioning correctly",
                    subject = "Product malfunction support",
                    email = "john.doe@example.com",
                    priority = 1, // Low priority
                    status = 2,   // Open status
                    cc_emails = new List<string> { "manager@example.com", "support_lead@example.com" }
                },
                new
                {
                    description = "Unable to access account",
                    subject = "Login issue assistance",
                    email = "jane.smith@example.com",
                    priority = 2, // Medium priority
                    status = 3,   // Pending status
                    cc_emails = new List<string> { "techsupport@example.com" }
                },
                new
                {
                    description = "Request for product information",
                    subject = "Product details inquiry",
                    email = "michael.jordan@example.com",
                    priority = 1, // Low priority
                    status = 2,   // Open status
                    cc_emails = new List<string> { "sales@example.com" }
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
