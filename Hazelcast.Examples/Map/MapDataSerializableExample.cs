﻿// Copyright (c) 2008-2015, Hazelcast, Inc. All Rights Reserved.
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
using Hazelcast.Examples.Models;

namespace Hazelcast.Examples.Map
{
    internal class MapDataSerializableExample
    {
        public static void Run(string[] args)
        {
            Environment.SetEnvironmentVariable("hazelcast.logging.level", "info");
            Environment.SetEnvironmentVariable("hazelcast.logging.type", "console");

            var config = new ClientConfig();
            config.GetNetworkConfig().AddAddress("127.0.0.1");

            var client = HazelcastClient.NewHazelcastClient(config);

            var map = client.GetMap<int, Person>("data-serializable-example");

            var person = new Person(1, "A person", 30);

            Console.WriteLine("Adding person: " + person);
            
            map.Put(person.Id, person);

            var p = map.Get(person.Id);

            Console.WriteLine("Gotten person: " + p);

            client.Shutdown();
        }
    }
}