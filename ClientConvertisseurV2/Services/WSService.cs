﻿using ClientConvertisseurV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Services
{
    public class WSService : IService
    {
        //string uri = new string("http://localhost:12278/");
        HttpClient client = new HttpClient();
        public WSService(string uri)
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:12278/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Devise>> GetDevisesAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Devise>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
