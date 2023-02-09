using System;
using Confluent.Kafka;

namespace KafkaConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            // the bootstrap server is the address of the kafka broker, i.e. the docker container. Here you can specify multiple brokers 
            // separated by a comma to enable load balancing and fault tolerance.
            // The group id is used to identify the consumer group. All consumers with the same group id belong to the same consumer group.
            // The auto offset reset defines the behavior of the consumer if no offset is stored for a partition. Here we set it to earliest
            var config = new ConsumerConfig
            {
                BootstrapServers = "kafka1:9092",
                GroupId = "example-consumer-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            string FileName = "the-rabbit-hole.txt";
            File.WriteAllText(FileName, "CONSUMERTEXT" + Environment.NewLine);

            using (var consumer = new ConsumerBuilder<Null, string>(config).Build())
            {
                consumer.Subscribe("TestTopic");

                Console.WriteLine("Kafka Consumer is running...");

                while (true)
                {
                    try
                    {
                        var message = consumer.Consume();

                        Console.WriteLine($"Message received: '{message.Value}' from partition {message.Partition} with offset {message.Offset}");
                        File.AppendAllText(FileName, message.Value);
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Consumption failed: {e.Error.Reason}");
                    }
                }
            }
        }
    }
}