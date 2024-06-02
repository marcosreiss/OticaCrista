using AutoMapper;
using OticaCrista.communication.Requests.Client;
using OticaCrista.communication.Responses.Client;
using SistOtica.Models.Client;

namespace OticaCrista.Application.Mapping
{
    public class ClientToResponse : Profile
    {
        public ClientToResponse()
        {
            CreateMap<ClientModel, ResponseClientJson>();
            CreateMap<ClientContact, ContactJson>();
            CreateMap<ClientReferences, ReferenceJson>();
        }
    }
}
