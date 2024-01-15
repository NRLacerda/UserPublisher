using Amazon.SQS;
using Amazon.SQS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UserPublisher
{
    public class SqsPublisher
    {
        private readonly IAmazonSQS _sqs;
        public SqsPublisher(IAmazonSQS sqs)
        {
            _sqs = sqs;

        }
        public async Task PublishAsync<T> (string queueName, T message)
        {
            var queueUrl = await _sqs.GetQueueUrlAsync(queueName);
            var request = new SendMessageRequest
            {
                QueueUrl = queueUrl.QueueUrl,
                MessageBody = JsonSerializer.Serialize(message),
                MessageGroupId = "1"
            };
            await _sqs.SendMessageAsync(request);
        }
    }
}
