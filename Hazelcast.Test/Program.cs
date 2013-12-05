﻿using System;
using System.Threading;
using Hazelcast.Client;
using Hazelcast.Config;
using Hazelcast.Core;
using Hazelcast.Net.Ext;

namespace Hazelcast.Test
{
    class Program
    {
        static void Main2(string[] args)
        {
            ClientConfig clientConfig = new ClientConfig();

            clientConfig.AddAddress("192.168.1.162");

            var hazelcast = HazelcastClient.NewHazelcastClient(clientConfig);

            var hzMap = hazelcast.GetMap<string,string>("mylist");

            //hzMap.Put("key1","Value1");
            //hzMap.Put("key2","Value2");
            //hzMap.Put("key3","Value3");
            //hzMap.Put("key4","Value4");


            Console.WriteLine(hzMap.Get("key1"));
            Console.WriteLine(hzMap.Get("key2"));
            Console.WriteLine(hzMap.Get("key3"));
            Console.WriteLine(hzMap.Get("key4"));

            Console.ReadKey();

        }

        static void Main11(string[] args)
        {
            ClientConfig clientConfig = new ClientConfig();

            clientConfig.AddAddress("127.0.0.1");

            var hazelcast = HazelcastClient.NewHazelcastClient(clientConfig);

            var list = hazelcast.GetList<object>("mylist");

            list.Add("Item 1");
            list.Add("Item 2");
            list.Add("Item 3");

            Console.WriteLine("count:"+list.Size());
            Console.ReadKey();
        }
        //{
        //    var bs = new ByteSerializer();

        //    Console.WriteLine(bs is ByteSerializer);
        //    Console.WriteLine(bs is SingletonSerializer<byte>);
        //    Console.WriteLine(bs is IStreamSerializer<byte>);

        //    Console.ReadKey();
        //}

        //private bool test<T>(T t)
        //{
            
        //}
    }

    //public sealed class ByteSerializer : SingletonSerializer<byte>
    //{Class1.cs
    //    public override int GetTypeId()
    //    {
    //        return 1;
    //    }

    //    /// <exception cref="System.IO.IOException"></exception>
    //    public override byte Read(object input)
    //    {
    //        return 1;
    //    }

    //    /// <exception cref="System.IO.IOException"></exception>
    //    public override void Write(object output, byte obj)
    //    {
    //        //
    //    }
    //}

    //public abstract class SingletonSerializer<T> : IStreamSerializer<T>
    //{
    //    public virtual void Destroy()
    //    {
    //    }

    //    public abstract int GetTypeId();

    //    public abstract T Read(object arg1);

    //    public abstract void Write(object arg1, T arg2);
    //}
    //public interface IStreamSerializer<T> : ISerializer
    //{
    //    /// <exception cref="System.IO.IOException"></exception>
    //    void Write(object output, T t);

    //    /// <exception cref="System.IO.IOException"></exception>
    //    T Read(object input);
    //}

    //public interface ISerializer
    //{
    //    int GetTypeId();

    //    void Destroy();
    //}
}