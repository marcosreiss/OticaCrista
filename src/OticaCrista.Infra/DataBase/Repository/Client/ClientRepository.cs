using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using OticaCrista.communication.Requests.Client;
using SistOtica.Models.Client;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Net.Mail;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

namespace OticaCrista.Infra.DataBase.Repository.Client
{
    public class ClientRepository(
        IDbContextFactory<OticaCristaContext> factory,
        ILogger<ClientRepository> _logger) : IClientRepository
    {
        private readonly OticaCristaContext _context = factory.CreateDbContext();

        private static ClientModel MapClient(ClientRequest request)
        {
            var client = new ClientModel
            {
                Name = request.Name,
                Cpf = request.Cpf,
                Rg = request.Rg,
                BornDate = request.BornDate,
                FatherName = request.FatherName,
                MotherName = request.MotherName,
                SpouseName = request.SpouseName,
                EmailAddress = request.EmailAddress,
                Company = request.Company,
                Ocupation = request.Ocupation,
                Street = request.Street,
                City = request.City,
                Neighborhood = request.Neighborhood,
                Uf = request.Uf,
                Cep = request.Cep,
                AddressComplement = request.AddressComplement,
                Negativated = request.Negativated,
                Observation = request.Observation,
            };
            return client;
        }


        #region Client

        public async Task<ClientModel?> CreateClientAsync(ClientRequest request)
        {
            try
            {
                var client = MapClient(request);

                var addClient = await _context.Clients.AddAsync(client);
                await _context.SaveChangesAsync();
                var clientPosted = addClient.Entity;

                if(request.Contacts != null)
                {
                    var contacts = request.Contacts;
                    foreach (var contact in contacts)
                    {
                        await CreateContactAsync(contact, clientPosted.Id);
                    }
                }

                if(request.References != null)
                {
                    var references = request.References;
                    foreach (var reference in references)
                    {
                        await CreateReferenceAsync(reference, clientPosted.Id);
                    }
                }

                return clientPosted;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ClientRepository.CreateClientAsync:\n" + ex.Message);
                throw new Exception("Erro em ClientRepository.CreateClientAsync: " + ex.Message);
            }
        }

        public async Task<ClientModel?> UpdateClientAsync(ClientRequest request, int id)
        {
            try
            {
                var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
                if (client == null)
                {
                    _logger.LogError("(ClientRepository.UpdateClientAsync): clientId passado inválido, client não encontrado");
                    return null;
                }

                client.Name = request.Name;
                client.Cpf = request.Cpf;
                client.Rg = request.Rg;
                client.BornDate = request.BornDate;
                client.FatherName = request.FatherName;
                client.MotherName = request.MotherName;
                client.SpouseName = request.SpouseName;
                client.EmailAddress = request.EmailAddress;
                client.Company = request.Company;
                client.Ocupation = request.Ocupation;
                client.Street = request.Street;
                client.City = request.City;
                client.Neighborhood = request.Neighborhood;
                client.Uf = request.Uf;
                client.Cep = request.Cep;
                client.AddressComplement = request.AddressComplement;
                client.Negativated = request.Negativated;
                client.Observation = request.Observation;

                var addClient = _context.Clients.Update(client);
                await _context.SaveChangesAsync();

                var clientUpdated = addClient.Entity;

                var contacts = request.Contacts;
                foreach (var contact in contacts)
                {
                    await UpdateContactAsync(contact, clientUpdated.Id);
                }

                var references = request.References;
                foreach (var reference in references)
                {
                    await UpdateReferenceAsync(reference, clientUpdated.Id);
                }

                return clientUpdated;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ClientRepository.UpdateClientAsync: " + ex.Message);
                throw new Exception("Erro em ClientRepository.UpdateClientAsync: " + ex.Message);
            }
        }

        public async Task<ClientModel?> DeleteClientAsync(int id)
        {
            try
            {
                var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
                if (client == null)
                {
                    _logger.LogError("(ClientRepository.DeleteClientAsync): clientId passado inválido, client não encontrado");
                    throw new ArgumentException("Id passádo inválido!");
                }
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
                return client;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ClientRepository.DeleteClientAsync:\n" + ex.Message);
                throw new Exception("Erro em ClientRepository.DeleteClientAsync:\n" + ex.Message);
            }
        }

        public async Task<ClientModel?> GetClientByIdAsync(int id)
        {
            try
            {
                var client = await _context.Clients
                .Include(client => client.Contacts)
                .Include(client => client.References)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
                if (client == null)
                {
                    _logger.LogError("(ClientRepository.GetClientByIdAsync): clientId passado inválido, client não encontrado");
                    throw new ArgumentException("(ClientRepository.GetClientByIdAsync): clientId passado inválido, client não encontrado");
                }
                return client;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ClientRepository.GetClientByIdAsync: " + ex.Message);
                throw new Exception("Erro em ClientRepository.GetClientByIdAsync: " + ex.Message);
            }
        }

        public async Task<List<ClientModel>?> GetAllClientsPaginadedAsync(int skip, int take)
        {
            try
            {
                var clients = await _context.Clients
                .Include(client => client.Contacts)
                .Include(client => client.References)
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();

                return clients;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ClientRepository.GetAllClientsPaginadedAsync:\n" + ex.Message);
                throw new Exception("Erro em ClientRepository.GetAllClientsPaginadedAsync:\n" + ex.Message);
            }
        }

        public async Task<int> GetClientCountAsync()
        {
            return await _context.Clients.AsNoTracking().CountAsync();
        }

        #endregion

        #region Contact

        public async Task<bool> CreateContactAsync(ContactJson request, int clientId)
        {
            try
            {
                var contact = new ClientContact
                {
                    PhoneNumber = request.PhoneNumber,
                    ClientId = clientId
                };
                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ClientRepository.CreateContactAsync:\n" + ex.Message);
                throw new Exception("Erro em ClientRepository.CreateContactAsync:\n" + ex.Message);
            }
        }

        public async Task<bool> UpdateContactAsync(ContactJson request, int clientId)
        {
            try
            {
                var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.ClientId == clientId);

                if (contact == null)
                {
                   await CreateContactAsync(request, clientId);
                }
                else
                {
                    contact.PhoneNumber = request.PhoneNumber;
                    _context.Contacts.Update(contact);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ClientRepository.UpdateContactAsync: " + ex.Message);
                throw new Exception("Erro em ClientRepository.UpdateContactAsync: " + ex.Message);
            }
        }

        public async Task<bool> DeleteContactAsync(int clientId)
        {
            try
            {
                var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.ClientId == clientId);

                if (contact == null)
                {
                    _logger.LogError("(ClientRepository.DeleteContactAsync): clientId passado inválido, contact não encontrado");
                    throw new ArgumentException("(ClientRepository.DeleteContactAsync): clientId passado inválido, contact não encontrado");
                }

                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ClientRepository.DeleteContactAsync:\n" + ex.Message);
                throw new Exception("Erro em ClientRepository.DeleteContactAsync:\n" + ex.Message);
            }
        }

        #endregion

        #region Reference

        public async Task<bool> CreateReferenceAsync(ReferenceJson request, int clientId)
        {
            try
            {
                var reference = new ClientReferences
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    ClientId = clientId
                };
                await _context.References.AddAsync(reference);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ClientRepository.CreateReferenceAsync: " + ex.Message);
                throw new Exception("Erro em ClientRepository.CreateReferenceAsync: " + ex.Message);
            }
        }

        public async Task<bool> UpdateReferenceAsync(ReferenceJson request, int id)
        {

            try
            {
                var reference = await _context.References.FirstOrDefaultAsync(x => x.ClientId == id);
                if (reference == null)
                {
                    await CreateReferenceAsync(request, id);
                }
                else
                {
                    reference.Name = request.Name;
                    reference.PhoneNumber = request.PhoneNumber;

                    _context.References.Update(reference);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ClientRepository.UpdateReferenceAsync:" + ex.Message);
                throw new Exception("Erro em ClientRepository.UpdateReferenceAsync:" + ex.Message);
            }
        }

        public async Task<bool> DeleteReferenceAsync(int id)
        {
            try
            {
                var reference = _context.References.FirstOrDefault(x => x.Id == id);
                if (reference == null)
                {
                    _logger.LogError("(ClientRepository.DeleteReferenceAsync): clientIdd pasado inválido, client não encontrada");
                    throw new ArgumentException("(ClientRepository.DeleteReferenceAsync): clientIdd pasado inválido, client não encontrada");
                }

                _context.References.Remove(reference);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro em ClientRepository.DeleteReferenceAsync:" + ex.Message);
                throw new Exception("Erro em ClientRepository.DeleteReferenceAsync:" + ex.Message);
            }
        }

        #endregion

        public async Task<bool> UniqueName(string name, CancellationToken cancellationToken)
        {

            return await _context.Clients.AllAsync(c => c.Name != name, cancellationToken);
        }

        public async Task<bool> UniqueCpf(string cpf, CancellationToken cancellationToken)
        {
            return await _context.Clients.AsNoTracking().AllAsync(client => client.Cpf != cpf, cancellationToken);  
        }

        
    }
}
