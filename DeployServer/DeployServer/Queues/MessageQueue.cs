using System.Collections.Concurrent;

namespace DeployServer.Queues
{
    public enum MsgType
    {
        MESSAGE,
        VERSION
    }
  
    public interface IMessageQueue<TClientID, TMsgType, TMsg>
    {
        void EnQueue(TClientID clientID, TMsgType msgType, TMsg msg);
        Task<QueueMessage<TClientID, TMsgType, TMsg>?> DeQueue(TClientID clientId, TMsgType msgType);
    }
    /// <summary>
    /// 消息队列
    /// </summary>
    public class MessageQueue<TClientID, TMsgType, TMsg>: IMessageQueue<TClientID, TMsgType, TMsg>
    {
        private ConcurrentBag<QueueMessage<TClientID, TMsgType, TMsg>> queueMessages;
        public MessageQueue()
        {
            queueMessages = new ConcurrentBag<QueueMessage<TClientID, TMsgType, TMsg>>();
        }
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="msg"></param>
        public void EnQueue(TClientID clientID, TMsgType msgType,TMsg msg)
        {
            queueMessages.Add(new QueueMessage<TClientID, TMsgType, TMsg>(clientID, msgType,msg) );
        }
        public async Task<QueueMessage<TClientID, TMsgType, TMsg>?> DeQueue(TClientID clientId,TMsgType msgType)
        {
            var msg = queueMessages.Where(e=>e.msgType.Equals(msgType) &&e.clientId.Equals(clientId)).FirstOrDefault();
            return msg;
        }


    }
    /// <summary>
    /// 消息结构
    /// </summary>
    public class QueueMessage<TClientID,TMsgType,TMsg>
    {
        public QueueMessage(TClientID clientID, TMsgType msgType, TMsg msg)
        {
            this.clientId = clientID;
            this.msg = msg;
            this.msgType = msgType;
        }
        /// <summary>
        /// 客户端ID
        /// </summary>
        public TClientID clientId { get; set; }
        public TMsgType msgType { get; set; }
        public TMsg msg { get; set; }
    }
}
