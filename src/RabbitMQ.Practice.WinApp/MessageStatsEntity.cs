namespace RabbitMQ.Practice.WinApp
{
    public class MessageStatsEntity
    {
        public int publish_in { get; set; }
        public PublishindetailsEntity publish_in_details { get; set; }
        public int publish_out { get; set; }
        public PublishoutdetailsEntity publish_out_details { get; set; }
    }
    
    public class PublishoutdetailsEntity
    {
        public double rate { get; set; }
    }

    public class PublishindetailsEntity
    {
        public double rate { get; set; }
    }
}