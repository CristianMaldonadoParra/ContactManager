//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TemplateSolution.Domain.Core.Core.Messaging;
//using TemplateSolution.Domain.Core.Events;

//namespace TemplateSolution.Infra.Data.EventSourcing
//{
//    public class SqlEventStore : IEventStore
//    {
//        private readonly IEventStoreRepository _eventStoreRepository;
//        //private readonly IAspNetUser _user;

//        public SqlEventStore(IEventStoreRepository eventStoreRepository)
//        {
//            _eventStoreRepository = eventStoreRepository;

//        }

//        public void Save<T>(T theEvent) where T : Event
//        {
//            var serializedData = JsonConvert.SerializeObject(theEvent);

//            var storedEvent = new TB_RH_StoredEvent(
//                theEvent,
//                serializedData,
//                "Nome do Usuario AQUI"
//                );

//            _eventStoreRepository.Store(storedEvent);
//        }
//    }
//}
