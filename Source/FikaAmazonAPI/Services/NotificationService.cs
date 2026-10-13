using Amazon.SQS;
using Amazon.SQS.Model;
using FikaAmazonAPI.AmazonSpApiSDK.Models.Notifications;
using FikaAmazonAPI.NotificationMessages;
using FikaAmazonAPI.Parameter.Notification;
using FikaAmazonAPI.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using static FikaAmazonAPI.AmazonSpApiSDK.Models.Token.CacheTokenData;
using static FikaAmazonAPI.Utils.Constants;

namespace FikaAmazonAPI.Services
{
    public class NotificationService : RequestService
    {
        public NotificationService(AmazonCredential amazonCredential, ILoggerFactory? loggerFactory) : base(amazonCredential, loggerFactory)
        {

        }

        //Read more about grant less opration
        //https://github.com/amzn/selling-partner-api-docs/blob/3fb7fcea1a828d31277a565af20cd4ef996b9dd7/guides/en-US/developer-guide/SellingPartnerApiDeveloperGuide.md#grantless-operations

        public Subscription GetSubscription(NotificationType notificationType) =>
            Task.Run(() => GetSubscriptionAsync(notificationType)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Subscription> GetSubscriptionAsync(NotificationType notificationType, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.GetSubscription(notificationType.ToString()), RestSharp.Method.Get, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetSubscriptionResponse>(RateLimitType.Notifications_GetSubscription, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Destination CreateDestination(CreateDestinationRequest request) =>
            Task.Run(() => CreateDestinationAsync(request)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Destination> CreateDestinationAsync(CreateDestinationRequest request, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.CreateDestination, RestSharp.Method.Post, postJsonObj: request, tokenDataType: TokenDataType.Grantless, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<CreateDestinationResponse>(RateLimitType.Notifications_CreateDestination, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public List<Destination> GetDestinations() =>
            Task.Run(() => GetDestinationsAsync()).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<List<Destination>> GetDestinationsAsync(CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.GetDestinations, RestSharp.Method.Get, tokenDataType: TokenDataType.Grantless, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetDestinationsResponse>(RateLimitType.Notifications_GetDestinations, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }
        public Destination GetDestination(string destinationId) =>
            Task.Run(() => GetDestinationAsync(destinationId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Destination> GetDestinationAsync(string destinationId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.GetDestination(destinationId), RestSharp.Method.Get, tokenDataType: TokenDataType.Grantless, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetDestinationResponse>(RateLimitType.Notifications_GetDestination, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public bool DeleteDestination(string destinationId) =>
            Task.Run(() => DeleteDestinationAsync(destinationId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> DeleteDestinationAsync(string destinationId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.DeleteDestination(destinationId), RestSharp.Method.Delete, tokenDataType: TokenDataType.Grantless, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<DeleteDestinationResponse>(RateLimitType.Notifications_DeleteDestination, cancellationToken);
            if (response != null && response.Errors != null)
                return false;
            return true;
        }


        public Subscription CreateSubscription(ParameterCreateSubscription param) =>
            Task.Run(() => CreateSubscriptionAsync(param)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Subscription> CreateSubscriptionAsync(ParameterCreateSubscription param, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.CreateSubscription(param.notificationType.ToString()), RestSharp.Method.Post, postJsonObj: param, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<CreateSubscriptionResponse>(RateLimitType.Notifications_CreateSubscription, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public Subscription GetSubscriptionById(NotificationType notificationType, string subscriptionId) =>
            Task.Run(() => GetSubscriptionByIdAsync(notificationType, subscriptionId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<Subscription> GetSubscriptionByIdAsync(NotificationType notificationType, string subscriptionId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.GetSubscriptionById(notificationType.ToString(), subscriptionId), RestSharp.Method.Get, tokenDataType: TokenDataType.Grantless, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<GetSubscriptionByIdResponse>(RateLimitType.Notifications_GetSubscriptionById, cancellationToken);
            if (response != null && response.Payload != null)
                return response.Payload;
            return null;
        }

        public bool DeleteSubscriptionById(NotificationType notificationType, string subscriptionId) =>
            Task.Run(() => DeleteSubscriptionByIdAsync(notificationType, subscriptionId)).ConfigureAwait(false).GetAwaiter().GetResult();
        public async Task<bool> DeleteSubscriptionByIdAsync(NotificationType notificationType, string subscriptionId, CancellationToken cancellationToken = default)
        {
            await CreateAuthorizedRequestAsync(NotificationApiUrls.DeleteSubscriptionById(notificationType.ToString(), subscriptionId), RestSharp.Method.Delete, tokenDataType: TokenDataType.Grantless, cancellationToken: cancellationToken);
            var response = await ExecuteRequestAsync<DeleteSubscriptionByIdResponse>(RateLimitType.Notifications_DeleteSubscriptionById, cancellationToken);
            if (response != null && response.Errors != null)
                return false;
            return true;
        }

        public static void StartReceivingNotificationMessages(ParameterMessageReceiver param, IMessageReceiver messageReceiver, bool isDeleteNotificationAfterRead = true) =>
            Task.Run(() => StartReceivingNotificationMessagesAsync(param, messageReceiver, isDeleteNotificationAfterRead)).ConfigureAwait(false).GetAwaiter().GetResult();

        public static void StartReceivingNotificationMessages(ParameterMessageReceiver param, IMessageReceiverWithResult messageReceiver, bool isDeleteNotificationAfterRead = false) =>
            Task.Run(() => StartReceivingNotificationMessagesAsync(param, messageReceiver, isDeleteNotificationAfterRead)).ConfigureAwait(false).GetAwaiter().GetResult();

        public static Task StartReceivingNotificationMessagesAsync(ParameterMessageReceiver param, IMessageReceiver messageReceiver, bool isDeleteNotificationAfterRead = true, CancellationToken cancellationToken = default)
        {
            return StartReceivingNotificationMessagesAsync(param, new MessageReceiverAdapter(messageReceiver), isDeleteNotificationAfterRead, cancellationToken);
        }

        /// <summary>
        /// Wait time used when the caller does not set ParameterMessageReceiver.WaitTimeSeconds.
        /// Long polling returns as soon as a message arrives and lets a single receive call fill
        /// up to MaxNumberOfMessages; short polling only samples a subset of the SQS servers and
        /// often returns one or two messages even when the queue holds thousands.
        /// </summary>
        private const int DefaultWaitTimeSeconds = 20;

        private const int MaxNumberOfMessagesPerReceive = 10;

        public static async Task StartReceivingNotificationMessagesAsync(ParameterMessageReceiver param, IMessageReceiverWithResult messageReceiver, bool isDeleteNotificationAfterRead = false, CancellationToken cancellationToken = default)
        {
            var awsAccessKeyId = param.awsAccessKeyId;
            var awsSecretAccessKey = param.awsSecretAccessKey;
            var SQS_URL = param.SQS_URL;
            var Region = param.RegionEndpoint;

            using (var amazonSQSClient = new AmazonSQSClient(awsAccessKeyId, awsSecretAccessKey, Region))
            {
                var waitTimeSeconds = param.WaitTimeSeconds ?? DefaultWaitTimeSeconds;

                ReceiveMessageRequest receiveMessageRequest = new ReceiveMessageRequest(SQS_URL);
                receiveMessageRequest.MaxNumberOfMessages = MaxNumberOfMessagesPerReceive;
                receiveMessageRequest.WaitTimeSeconds = waitTimeSeconds;

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var result = await amazonSQSClient.ReceiveMessageAsync(receiveMessageRequest, cancellationToken);
                        var Messages = result.Messages ?? new List<Message>();

                        var messagesToDelete = new List<Message>(Messages.Count);
                        foreach (var msg in Messages)
                        {
                            if (ProcessNotificationMessage(msg, messageReceiver, isDeleteNotificationAfterRead))
                                messagesToDelete.Add(msg);
                        }

                        await DeleteMessagesFromQueueAsync(amazonSQSClient, SQS_URL, messagesToDelete, messageReceiver, cancellationToken).ConfigureAwait(false);

                        // Only back off on an empty queue, and only when the caller turned long
                        // polling off - otherwise the receive call above already did the waiting.
                        // Sleeping on any partial batch throttles exactly the case we care about,
                        // a queue that has a backlog.
                        if (Messages.Count == 0 && waitTimeSeconds <= 0)
                            await Task.Delay(1000 * 5, cancellationToken).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        return;
                    }
                    catch (Exception ex)
                    {
                        messageReceiver.ErrorCatch(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Hands one message to the receiver and reports whether it should be deleted.
        /// </summary>
        private static bool ProcessNotificationMessage(Message msg, IMessageReceiverWithResult messageReceiver, bool isDeleteNotificationAfterRead)
        {
            var deleteMessage = isDeleteNotificationAfterRead;
            try
            {
                var data = DeserializeNotification(msg);

                deleteMessage = messageReceiver.NewMessageRevicedTriger(data) || isDeleteNotificationAfterRead;
            }
            catch (Exception ex)
            {
                messageReceiver.ErrorCatch(ex);
            }

            return deleteMessage;
        }

        /// <summary>
        /// Deletes a whole receive batch with one API call instead of one call per message.
        /// </summary>
        private static async Task DeleteMessagesFromQueueAsync(AmazonSQSClient sqsClient, string QueueUrl, IList<Message> messages, IMessageReceiverWithResult messageReceiver, CancellationToken cancellationToken = default)
        {
            if (messages == null || messages.Count == 0)
                return;

            var entries = new List<DeleteMessageBatchRequestEntry>(messages.Count);
            for (var i = 0; i < messages.Count; i++)
                entries.Add(new DeleteMessageBatchRequestEntry(i.ToString(), messages[i].ReceiptHandle));

            var response = await sqsClient.DeleteMessageBatchAsync(
                new DeleteMessageBatchRequest(QueueUrl, entries), cancellationToken).ConfigureAwait(false);

            // A message that fails to delete stays invisible until its visibility timeout runs
            // out and is then redelivered, so the caller needs to know about it.
            if (response.Failed != null && response.Failed.Count > 0)
            {
                var failed = response.Failed[0];
                messageReceiver.ErrorCatch(new AmazonSQSException(
                    "Failed to delete " + response.Failed.Count + " of " + messages.Count +
                    " message(s) from " + QueueUrl + ". First failure: " + failed.Code + " " + failed.Message));
            }
        }
        private static NotificationMessageResponce DeserializeNotification(Message message)
        {

            NotificationMessageResponce notification;

            using (TextReader reader = new StringReader(message.Body))
            {
                notification = JsonConvert.DeserializeObject<NotificationMessageResponce>(message.Body); ;
            }

            return notification;
        }

        private class MessageReceiverAdapter : IMessageReceiverWithResult
        {
            private readonly IMessageReceiver _receiver;

            public MessageReceiverAdapter(IMessageReceiver receiver)
            {
                _receiver = receiver;
            }

            public void ErrorCatch(Exception ex)
            {
                _receiver.ErrorCatch(ex);
            }

            public bool NewMessageRevicedTriger(NotificationMessageResponce message)
            {
                _receiver.NewMessageRevicedTriger(message);
                return false;
            }
        }
    }
}
