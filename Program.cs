using Amazon.SQS;
using UserPublisher;
using UserPublisher.Messages;
using Newtonsoft.Json;


//O AWSconfig app deve estar no mesmo diretório de program.cs

string jsonFilePath = "Ponha aqui o fullPath do awsConfigApp.json";
string jsonContent = File.ReadAllText(jsonFilePath);
dynamic config = JsonConvert.DeserializeObject(jsonContent);

string accessKey = config.AWSAccessKey;
string secretKey = config.AWSSecretKey;
string queueName = config.QueueName;

var sqsClient = new AmazonSQSClient(
    awsAccessKeyId: accessKey,
    awsSecretAccessKey: secretKey,
    region: Amazon.RegionEndpoint.USEast1
);

var sqsPublisher = new SqsPublisher(sqsClient);
await sqsPublisher.PublishAsync(queueName, new UserCreated
{
    UserID = 1,
    UserName = "teste",
    Email = "queueName@gmail.com"
});
Console.ReadLine();