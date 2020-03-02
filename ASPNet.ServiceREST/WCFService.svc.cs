using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace ASPNet.ServiceREST
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WCFService
    {
        private static List<string> lst = new List<string>
        {
            "Arrays",
            "Queues",
            "Stacks"
        };

        [WebGet(UriTemplate = "/Tutorial")]
        public string GetAllTutorials() => String.Join(",", lst);

        [WebGet(UriTemplate = "/Tutorial/{TutorialId}")]
        public string GetTutorialByID(string TutorialId)
        {
            int pid;
            if (!int.TryParse(TutorialId, out pid))
            {
                throw new HttpResponseException("TutorialId must be an integer", HttpStatusCode.BadRequest);
            }
            return lst[pid];
        }

        [WebInvoke(Method = "POST", 
         RequestFormat = WebMessageFormat.Json, 
         UriTemplate = "/Tutorial", 
         ResponseFormat = WebMessageFormat.Json, 
         BodyStyle = WebMessageBodyStyle.Wrapped)]
        public void AddTutorial(string str) => lst.Add(str);

        [WebInvoke(Method = "DELETE", 
         RequestFormat = WebMessageFormat.Json,
         UriTemplate = "/Tutorial/{TutorialId}", 
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Wrapped)]

        public void DeleteTutorial(string TutorialId)
        {
            int pid;
            if (!int.TryParse(TutorialId, out pid))
            {
                throw new HttpResponseException("TutorialId must be an integer", HttpStatusCode.BadRequest);
            }
            lst.RemoveAt(pid);
        }

        // Чтобы использовать протокол HTTP GET, добавьте атрибут [WebGet]. (По умолчанию ResponseFormat имеет значение WebMessageFormat.Json.)
        // Чтобы создать операцию, возвращающую XML,
        //     добавьте [WebGet(ResponseFormat=WebMessageFormat.Xml)]
        //     и включите следующую строку в текст операции:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void DoWork()
        {
            // Добавьте здесь реализацию операции
            return;
        }

        // Добавьте здесь дополнительные операции и отметьте их атрибутом [OperationContract]
    }
}
