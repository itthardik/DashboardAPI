using Newtonsoft.Json;

namespace Dashboard.Models
{
#pragma warning disable 1591
    namespace Dashboard.Models
    {
        public class Ticket
        {
            [JsonProperty("cc_emails")]
            public List<string>? CcEmails { get; set; }

            [JsonProperty("fwd_emails")]
            public List<string>? FwdEmails { get; set; }

            [JsonProperty("reply_cc_emails")]
            public List<string>? ReplyCcEmails { get; set; }

            [JsonProperty("ticket_cc_emails")]
            public List<string>? TicketCcEmails { get; set; }

            [JsonProperty("fr_escalated")]
            public bool? FrEscalated { get; set; }

            [JsonProperty("spam")]
            public bool? Spam { get; set; }

            [JsonProperty("email_config_id")]
            public long? EmailConfigId { get; set; }

            [JsonProperty("group_id")]
            public long? GroupId { get; set; }

            [JsonProperty("priority")]
            public long? Priority { get; set; }

            [JsonProperty("requester_id")]
            public long? RequesterId { get; set; }

            [JsonProperty("responder_id")]
            public long? ResponderId { get; set; }

            [JsonProperty("source")]
            public long? Source { get; set; }

            [JsonProperty("company_id")]
            public long? CompanyId { get; set; }

            [JsonProperty("status")]
            public long? Status { get; set; }

            [JsonProperty("subject")]
            public string? Subject { get; set; }

            [JsonProperty("association_type")]
            public string? AssociationType { get; set; }

            [JsonProperty("support_email")]
            public string? SupportEmail { get; set; }

            [JsonProperty("to_emails")]
            public List<string>? ToEmails { get; set; }

            [JsonProperty("product_id")]
            public long? ProductId { get; set; }

            [JsonProperty("id")]
            public long? Id { get; set; }

            [JsonProperty("type")]
            public string? Type { get; set; }

            [JsonProperty("created_at")]
            public string? CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public string? UpdatedAt { get; set; }

            [JsonProperty("due_by")]
            public string? DueBy { get; set; }

            [JsonProperty("fr_due_by")]
            public string? FrDueBy { get; set; }

            [JsonProperty("is_escalated")]
            public bool? IsEscalated { get; set; }

            [JsonProperty("description")]
            public string? Description { get; set; }

            [JsonProperty("description_text")]
            public string? DescriptionText { get; set; }

            [JsonProperty("custom_fields")]
            public CustomFields? CustomFields { get; set; }

            [JsonProperty("tags")]
            public List<string>? Tags { get; set; }

            [JsonProperty("attachments")]
            public List<string>? Attachments { get; set; }

            [JsonProperty("source_additional_info")]
            public string? SourceAdditionalInfo { get; set; }

            [JsonProperty("stats")]
            public Stats? Stats { get; set; }

            [JsonProperty("form_id")]
            public long? FormId { get; set; }

            [JsonProperty("sentiment_score")]
            public long? SentimentScore { get; set; }

            [JsonProperty("initial_sentiment_score")]
            public long? InitialSentimentScore { get; set; }

            [JsonProperty("nr_due_by")]
            public string? NrDueBy { get; set; }

            [JsonProperty("nr_escalated")]
            public bool? NrEscalated { get; set; }
        }

        public class CustomFields
        {
            [JsonProperty("cf_reference_number")]
            public string? CfReferenceNumber { get; set; }

            [JsonProperty("category")]
            public string? Category { get; set; }
        }

        public class Stats
        {
            [JsonProperty("agent_responded_at")]
            public string? AgentRespondedAt { get; set; }

            [JsonProperty("requester_responded_at")]
            public string? RequesterRespondedAt { get; set; }

            [JsonProperty("first_responded_at")]
            public string? FirstRespondedAt { get; set; }

            [JsonProperty("status_updated_at")]
            public string? StatusUpdatedAt { get; set; }

            [JsonProperty("reopened_at")]
            public string? ReopenedAt { get; set; }

            [JsonProperty("resolved_at")]
            public string? ResolvedAt { get; set; }

            [JsonProperty("closed_at")]
            public string? ClosedAt { get; set; }

            [JsonProperty("pending_since")]
            public string? PendingSince { get; set; }
        }
    }
}