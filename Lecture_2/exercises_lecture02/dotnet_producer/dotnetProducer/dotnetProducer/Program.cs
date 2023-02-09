using System;
using Confluent.Kafka;

namespace DotnetKafkaProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            // the bootstrap server is the address of the kafka broker, i.e. the docker container. Here you can specify multiple brokers 
            // separated by a comma to enable load balancing and fault tolerance.
            var config = new ProducerConfig { BootstrapServers = "kafka1:9092" };
            string aliceText = File.ReadAllText("alice-in-wonderland.txt");

            string[] text = aliceText.Split(' ');

            

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                Console.WriteLine("A kafka message");

                for (int i = 0; i < text.Length; i++)
                {
                    try
                    {
                        var message = $"{text[i]} ";
                        var result = producer.ProduceAsync("TestTopic", new Message<Null, string> { Value = message }).Result;

                        Console.WriteLine($"Message '{message}' sent to partition {result.Partition} with offset {result.Offset}");
                    }
                    catch (ProduceException<Null, string> e)
                    {
                        Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}