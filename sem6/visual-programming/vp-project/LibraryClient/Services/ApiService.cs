using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryClient.Services
{
    public static class ApiService
    {
        private static readonly HttpClient _httpClient;

        static ApiService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("http://localhost:5298/api/")
            };
        }

        public static async Task<List<T>?> GetAsync<T>(string endpoint)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<T>>(endpoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in GetAsync: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<T?> GetSingleAsync<T>(string endpoint)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<T>(endpoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in GetSingleAsync: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public static async Task<T?> PostAsync<T>(string endpoint, object data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(endpoint, data);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in PostAsync: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default;
            }
        }

        public static async Task<bool> PutAsync(string endpoint, object data)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(endpoint, data);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in PutAsync: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static async Task<bool> DeleteAsync(string endpoint)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(endpoint);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in DeleteAsync: {ex.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
