using Api_Verdureria.DTOs;
using Api_Verdureria.Modelos;
using Api_Verdureria.Models.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Verdureria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        public ClienteController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

        // GET: api/<ClienteController>
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta res = new Respuesta();
            try
            {
                using (DbVerdurasContext db = new DbVerdurasContext())
                {
                    var lista = db.Clientes.OrderByDescending(d=>d.ClienteId).ToList();
                    res.Succes = 1;
                    res.Data = lista;
                }
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
            }
            return Ok(res);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Post([FromBody] ClienteDTO clienteDTO)
        {
            Respuesta res = new Respuesta();
            try
            {
                using (DbVerdurasContext db = new DbVerdurasContext())
                {
                    var cliente = _mapper.Map<Cliente>(clienteDTO);
                    db.Add(cliente);
                    db.SaveChanges();
                    res.Succes = 1;
                    res.Data = cliente;
                }
            }
            catch (Exception ex)
            {
                res.Message = ex.Message;
            }
            return Ok(res);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClienteDTO clienteDTO)
        {
            Respuesta res = new Respuesta();
            try
            {
                using (DbVerdurasContext db = new DbVerdurasContext())
                {
                    var cliente = db.Clientes.Find(id);
                    if(cliente != null)
                    {
                        _mapper.Map(clienteDTO, cliente);
                        db.SaveChanges();
                        res.Succes = 1;
                        res.Data = cliente;
                    }
                    else
                    {
                        res.Message = "Cliente no encontrado";
                    }
                }
            }
    catch (Exception ex)
            {
                res.Message = ex.Message;
            }
            return Ok(res);
        }



        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Respuesta response = new Respuesta();
            try
    {
                using (DbVerdurasContext db = new DbVerdurasContext())
                {
                    var cliente = db.Clientes.Find(id);
                    if(cliente != null)
                    {
                        db.Remove(cliente);
                        db.SaveChanges();
                        response.Succes = 1;
                        response.Message = "Cliente con ID " + id.ToString() + " eliminado";
                    }
                    else
                    {
                        response.Message = "Error: Cliente no encontrado";
                    }
                }
            }
    catch (Exception ex)
            {
                response.Message = "Error: Error al eliminar el cliente de la base de datos. " + ex.Message;
            }
            return Ok(response);
        }
    }
}
