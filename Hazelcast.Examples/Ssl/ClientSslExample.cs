// Copyright (c) 2008-2019, Hazelcast, Inc. All Rights Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using Hazelcast.Client;
using Hazelcast.Config;

namespace Hazelcast.Examples.Ssl
{
    public class ClientSslExample
    {
        private static void Run(string[] args)
        {
            Environment.SetEnvironmentVariable("hazelcast.logging.level", "info");
            Environment.SetEnvironmentVariable("hazelcast.logging.type", "console");

            var clientConfig = new ClientConfig();
            var clientNetworkConfig = clientConfig.GetNetworkConfig();

            //replace with your actual server host/ip and port
            clientNetworkConfig.AddAddress("127.0.0.1:5701");

            //Server certificate will be validated by OS,
            //signed certificates will just work,
            //self-signed certificates should be registered by OS depended way and allowed.
            clientNetworkConfig.GetSSLConfig().SetEnabled(true);

            //in order to disable certificate validating uncomment below line
            //clientNetworkConfig.GetSSLConfig().SetProperty(SSLConfig.ValidateCertificateChain, "false");

            //in order to validate the server certificate name use below
            //clientNetworkConfig.GetSSLConfig().SetProperty(SSLConfig.ValidateCertificateName, "true");
            //clientNetworkConfig.GetSSLConfig().SetProperty(SSLConfig.CertificateName, "CERTIFICATE CN OR SAN VALUE HERE");

            var client = HazelcastClient.NewHazelcastClient(clientConfig);

            var map = client.GetMap<string, string>("ssl-example");

            map.Put("key", "value");

            Console.WriteLine("Key: " + map.Get("key"));

            map.Destroy();
            client.Shutdown();
        }
    }
}