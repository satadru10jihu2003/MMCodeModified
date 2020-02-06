using MeetingManagerAPI.Common;
using MeetingManagerAPI.Connectors;
using MeetingManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingManagerAPI.Providers
{
    public class ScheduleMeetingProvider
    {
        private static Dictionary<string, ContextStorage> storehouse = new Dictionary<string, ContextStorage>();
        private string[] iNeed3Things = { "Who", "When", "Where" };
        public string GetChatResponse(string question, string sessionId)
        {
            ContextStorage objStorage = new ContextStorage();
            if (!storehouse.Keys.Contains(sessionId))
                storehouse.Add(sessionId, objStorage);
            else
                objStorage = storehouse[sessionId];            

            LUISConnector objConn = new LUISConnector();
            LUISModel objModel = objConn.GetLUISResponse(question);            

            switch(objModel.TopScoringIntent.IntentName)
            {
                case "Schedule":
                    return ProcessSchedule(objModel, objStorage);                    
                default:
                    return string.Empty;
            }             
        }

        private string ProcessSchedule(LUISModel objModel, ContextStorage storageItem)
        {
            Entity[] arrEntity = objModel.Entities;
            foreach(Entity item in arrEntity)
            {
                switch(item.Type)
                {
                    case "builtin.personName":
                        storageItem.Who = item.EntityName;
                        break;
                    case "builtin.geographyV2":
                        storageItem.Where = item.EntityName;
                        break;
                    case "builtin.datetimeV2":
                        storageItem.When = ParseDateTimeEquivalent(item.EntityName);
                        break;
                }
            }

            if (!storageItem.isWhoAvailable)
                return QuestionStore.Q_Who_Needed;
            else if (!storageItem.isWhenAvailable)
                return QuestionStore.Q_When_Needed;
            else if (!storageItem.isWhereAvailable)
                return QuestionStore.Q_Where_Needed;
            else
                return string.Empty;
        }

        private DateTime ParseDateTimeEquivalent(string entityName)
        {
            throw new NotImplementedException();
        }
    }
}
