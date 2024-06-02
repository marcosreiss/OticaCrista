using AutoMapper;
using OticaCrista.communication.Requests.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Application.Mapping
{
    public class RequestToClient : Profile
    {
        public RequestToClient()
        {
            CreateMap<RequestClientJson, ClientModel>();
            CreateMap<ContactJson, ClientContact>();
            CreateMap<ReferenceJson, ClientReferences>();
        }
    }
}
