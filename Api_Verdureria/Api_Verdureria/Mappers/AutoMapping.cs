using Api_Verdureria.DTOs;
using Api_Verdureria.Modelos;
using AutoMapper;

namespace Api_Verdureria.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ClienteDTO, Cliente>();
        }
        //para usar en el controller
        /*
         private readonly IMapper _mapper;
        public ClienteController(IMapper mapper){
            _mapper = mapper;
        }

        en el POST ext, viene clienteDTO por parametro desde el [fromBody]
        var cliente = _mapper.Map<Cliente> (clienteDTO);
         */

    }
}
