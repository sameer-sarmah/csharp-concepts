using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using csharp_concepts.collection;
using csharp_concepts.concurrency;
using csharp_concepts.concurrency.barrier;
using csharp_concepts.concurrency.countdownlatch;
using csharp_concepts.concurrency.producer.consumer.blockingqueue;
using csharp_concepts.concurrency.producer.consumer.locks;
using csharp_concepts.concurrency.semaphore;
using csharp_concepts.io;
using csharp_concepts.io.json;
using csharp_concepts.io.txt;
using csharp_concepts.io.xml;
using csharp_concepts.mysql;

namespace csharp_concepts
{
    class Driver
    {
        static void Main(string[] args)
        {
            string multiline = @"
                <container>
                    <element>
                        value
                    </element>
                </container>
            ";
            //Collections.list();
            //Collections.map();
            //CollectionsDemo.list();
            //Collections.set();
            //Collections.linqUsingDSL();
            //Collections.linqUsingMethods();

            //DelegateDemo.delegateDemo();
            //var instance = new DelegateDemo(1, 2, 3, 4, 5);
            //var total = instance.getDelegateInstance()();
            //Console.WriteLine($"the total using delegate is {total}");
            // total = instance.getFunctionReference()();
            //Console.WriteLine($"the total using func reference is {total}");
            //StringBuilder builder = new StringBuilder();
            //ThreadDemo.tasks();
            //Concurrency.asyncAwait();
            //FP.functionalProg();
            //Concurrency.threads();
            //Concurrency.promises();
            //HttpCallCountDownLatch.httpCallParallelly();
            //ToiletManager.manage();

            //Runner.launch();
            //Launcher.launch();
            //BarrierDriver.launch();
            //FileIO.launch();
            // TextProcessor.process();
            //JsonProcessor.process();
            //XMLProcessor.process();
            //YieldPeople.yieldPerson();
            //MySQLConnection dao = new MySQLConnection();
            //dao.executeQuery();
            ODBCConnection oDBCConnection = new ODBCConnection();
            oDBCConnection.executeQuery();
        }


    }
    


}
