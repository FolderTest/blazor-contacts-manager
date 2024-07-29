using System.Net.Http.Json;
using ContactManager.Shared.Models;

namespace ContactManager.Client.Services
{
    public class ContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Contact>>("api/contacts");
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _httpClient.GetFromJsonAsync<Contact>($"api/contacts/{id}");
        }

        public async Task CreateContact(Contact contact)
        {
            await _httpClient.PostAsJsonAsync("api/contacts", contact);
        }

        public async Task UpdateContact(Contact contact)
        {
            await _httpClient.PutAsJsonAsync($"api/contacts/{contact.Id}", contact);
        }

        public async Task DeleteContact(int id)
        {
            await _httpClient.DeleteAsync($"api/contacts/{id}");
        }
    }
}