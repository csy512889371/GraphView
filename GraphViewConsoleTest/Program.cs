﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphView;
using System.Diagnostics;
using GraphViewUnitTest;
using System;
using GraphView;
using GraphViewUnitTest.Gremlin;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using System.Threading;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace GraphViewConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //partitionQueryTestCommon("MarvelTest");
            //Console.WriteLine("#######start PartitionTestCit test");
            //partitionQueryTestCommon("PartitionTestCit");
            //Console.WriteLine("#######start PartitionTestCitRep2 test");
            //partitionQueryTestCommon("PartitionTestCitRep2");
            //insertCitDataBulkInsert();
            // insertCitHashPartitionByBulkInsert();
            //insertCitGreedyPartitionByBulkInsert("CitGreedyPartition1000item");
            // getStatistic();
            //insertInSamePartition();

            //insertCitHashPartitionByBulkInsert("CitHashPartition1000item");
            //insertCitHashPartitionByBulkInsert("CitGreedyPartition1000item");

            //insertCitHashPartitionByBulkInsert("CitHashPartitionAllData");
            //insertCitHashPartitionByBulkInsert("CitGreedyPartitionAllData");
            //repartition("CitGreedyPartitionAllData", "CitGreedyPartitionAllData");

            //partitionQueryTestCommon("CitFakeDiffPartition", "CitFakeDiffPartition");
            //partitionQueryTestCommon("CitFakeDiffPartition", "CitFakeSamePartition");
            //partitionQueryTestCommon("CitHashPartition1000item", "CitHashPartition1000item");
            //partitionQueryTestCommon("CitHashPartition1000item", "CitGreedyPartition1000item");

            //partitionQueryTestCommon("CitHashPartitionAllData", "CitHashPartitionAllData");
            //partitionQueryTestCommon("CitHashPartitionAllData", "CitGreedyPartitionAllData");

            //insertDiffKeyPartitionBulkInsert("PartitionTest_100Key", 100);
            //insertDiffKeyPartitionBulkInsert("PartitionTest_50Key",50);
            //insertDiffKeyPartitionBulkInsert("PartitionTest_10Key", 10);
            //insertDiffKeyPartitionBulkInsert("PartitionTest_3Key", 3);
            //insertDiffKeyPartitionBulkInsert("PartitionTest_3Key", 1);
            //partitionQueryTestCommon("PartitionTest_3Key", "PartitionTest_100Key");
            //partitionQueryTestCommon("PartitionTest_3Key", "PartitionTest_50Key");
            //partitionQueryTestCommon("PartitionTest_3Key", "PartitionTest_10Key");
            //partitionQueryTestCommon("PartitionTest_3Key", "PartitionTest_3Key");
            //partitionQueryTestCommon("PartitionTest_3Key", "PartitionTest_1Key");
            //insertControlPartitionkeyBulkInsert("PartitionQueryCheck_100", 100);
            //partitionQueryDiffPartitionTest("PartitionQueryCheck_100");
            //querySpecificIDsList("PartitionQueryCheck_100");
            //querySpecificIDsListUseSystemCall_SameVertexCount_DiffPartitionNum("PartitionQueryCheck_100");
            //insertClusterNodeFakeBulkInsert("FakeCrossPartition", 30, true);
            //insertClusterNodeFakeBulkInsert("FakeNotCrossPartition", 30, false);
            //querySpecificIDsListUseSystemCall_SamePartitionCount_DiffVertexCount("PartitionQueryCheck_100");
            //int offset = 0;
            //for (int i = 0; i < 100; i++)
            //{
            //    //if(offset > 200)
            //    //{
            //    //    int a = 0;
            //    //}
            //    insertControlPartitionkeyBulkInsert_ExtremeCaseInOnePartition("PartitionQueryCheckExtremeIn1Partition", 100, offset);
            //    //insertControlPartitionkeyBulkInsert_ExtremeCase("PartitionQueryCheckExtremeDiffPartitionCase", 100, offset);
            //    offset += 100;
            //}
            //querySpecificIDsListUseSystemCall_SamePartitionCount_DiffVertexCount_ExtremeVertexCount("PartitionQueryCheckExtremeDiffPartitionCase");
            //insertSameVertexCountDiffPartitionCount("PartitionQueryCheckExtremeDiffPartitionCase");

            //querySpecificIDsListUseSystemCall_DiffVertexCount_SamePartitionNum("PartitionQueryCheckExtremeIn1Partition");

            //queryComparePartitionInCondition("PartitionQueryCheck_100");
            //queryCrossOrFakePartitionCross("FakeCrossPartition");
            //queryCrossOrFakePartitionNotCross("FakeNotCrossPartition");
            //repartition("CitGreedyPartition1000item", "CitGreedyPartition1000item");
            //randomDistributionExperimentRunner_2hop("CitHashPartition1000item", "CitHashPartition1000item");
            //randomDistributionExperimentRunner_2hop("CitHashPartition1000item", "CitGreedyPartition1000item");

            //randomDistributionExperimentRunner_ShortestPath("CitHashPartition1000item", "CitHashPartition1000item");
            //randomDistributionExperimentRunner_ShortestPath("CitHashPartition1000item", "CitGreedyPartition1000item");

            //randomDistributionExperimentRunner_2hop("CitHashPartitionAllData", "CitHashPartitionAllData");
            // randomDistributionExperimentRunner_2hop("CitHashPartitionAllData", "CitGreedyPartitionAllData");

            //randomDistributionExperimentRunner_3hop("CitHashPartitionAllData", "CitHashPartitionAllData");
            //randomDistributionExperimentRunner_3hop("CitHashPartitionAllData", "CitGreedyPartitionAllData");

            //randomDistributionExperimentRunner_4hop("CitHashPartitionAllData", "CitHashPartitionAllData");
            //randomDistributionExperimentRunner_4hop("CitHashPartitionAllData", "CitGreedyPartitionAllData");

            randomDistributionExperimentRunner_ShortestPath("CitHashPartitionAllData", "CitHashPartitionAllData");
            randomDistributionExperimentRunner_ShortestPath("CitHashPartitionAllData", "CitGreedyPartitionAllData");
            //statisticAllThePartitionAndDegreeInformation("CitHashPartitionAllData");
            //statisticAllThePartitionAndDegreeInformation("CitGreedyPartitionAllData");
            //repeatSSSPTest("CitHashPartition1000item");
            Console.ReadLine();
            // CitGreedyRePartition1000Item
        }

        public static void repeatSSSP(GraphViewCommand graph, String src, String des)
        {
            var traversal = graph.g()
                        .V(src)
                        .Repeat(GraphTraversal2.__().Out("appear"))
                        .Until(GraphTraversal2.__().Has("id", des))
                        .Limit(1);

            foreach (var t in traversal)
            {
                Console.WriteLine(t);
                break;
            }
        }

        public static void repeatSSSPTest(String collectionName)
        {
            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
             "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
             "GroupMatch", collectionName, GraphType.GraphAPIOnly, false,
             1, null);
            GraphViewCommand graph = new GraphViewCommand(connection);
            //var traversal = graph.g().V("0").Emit().Repeat(GraphTraversal2.__().Out("appear")).Times(2).Path();

            var traversal = graph.g()
                        .V("1001")
                        .Repeat(GraphTraversal2.__().Out("appear"))
                        .Until(GraphTraversal2.__().Has("id", "9502072"))
                        .Limit(1);

            foreach (var t in traversal)
            {
                Console.WriteLine(t);
                break;
            }
        }

        public static void randomDistributionExperimentRunner_ShortestPath(String sampleCollectionName, String collectionName)
        {
            Dictionary<String, long> resultStatistic = new Dictionary<string, long>();
            GraphViewConnection connection0 = new GraphViewConnection("https://graphview.documents.azure.com:443/",
              "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
              "GroupMatch", sampleCollectionName, GraphType.GraphAPIOnly, false,
              1, null);
            GraphViewCommand graph0 = new GraphViewCommand(connection0);
            List<Object> vertexIds0 = new List<object>();

            var start10 = Stopwatch.StartNew();
            var results0 = graph0.g().V().Sample(100).Values("id").Next();

            foreach (var result in results0)
            {
                vertexIds0.Add(result);
            }
            start10.Stop();
            Console.WriteLine("sample vertex " + 1 + "  " + sampleCollectionName + "(0)" + (start10.ElapsedMilliseconds) + "ms");


            var lines = new List<String>();
            var timeCollection = new List<long>();

            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
              "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
              "GroupMatch", collectionName, GraphType.GraphAPIOnly, false,
              1, null);
            GraphViewCommand graph = new GraphViewCommand(connection);
            //// warm query
            //var re = graph.g().V("9345").Out("appear").Out("appear").Next();
            //// warm query

            var linesE = File.ReadLines("E:\\dataset\\thsinghua_dataset\\p2p-Gnutella08\\p2p-Gnutella08.txt");
            String src = "0";

            var start3 = new Stopwatch();
            int i = 0;
            foreach (var node in linesE)
            {
                //if (i == 2)
                //{
                    var edge = node.Split('\t');
                    src = edge[0].ToString();
                    String des = edge[1].ToString();
                    // warm
                    var tempR = graph0.g().V("0").Values("id").Next();
                    foreach (var r in tempR)
                    {
                        var t = r;
                        break;
                    }
                    // warm
                    start3.Reset();
                    start3.Start();
                    //ShortestPathTest.GetShortestPath(src, des, graph);
                    repeatSSSP(graph, src, des);
                    start3.Stop();
                    Console.WriteLine(collectionName + "(3)" + (start3.ElapsedMilliseconds) + "ms");
                    timeCollection.Add(start3.ElapsedMilliseconds);
                //}
                i++;
                if (i > 30)
                {
                    break;
                }
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\project\GraphView_partition_temp\log\" + collectionName + "_ShortestPathRandomDistribution_1hop.txt"))
            {
                foreach (var line in timeCollection)
                {
                    file.WriteLine(line);
                }
            }
            // 2 hop shortest path
            //timeCollection.Clear();
            //linesE = File.ReadLines("E:\\dataset\\thsinghua_dataset\\p2p-Gnutella08\\p2p-Gnutella08.txt");
            //src = "0";
            //i = 0;
            //foreach (var node in linesE)
            //{
            //    //if (i == 5)
            //    //{
            //        var edge = node.Split('\t');
            //        src = edge[0].ToString();
            //        String des = edge[1].ToString();
            //        // warm
            //        var tempR = graph0.g().V(src).Out("appear").Out("appear").Values("id").Next();
            //        if (tempR.Count != 0)
            //        {
            //            foreach (var v in tempR)
            //            {
            //                des = v;
            //                break;
            //            }
            //        }
            //        else
            //        {
            //            continue;
            //        }
            //        // warm
            //        start3.Reset();
            //        start3.Start();
            //        ShortestPathTest.GetShortestPath(src, des, graph);
            //        start3.Stop();
            //        Console.WriteLine(collectionName + "(3)" + (start3.ElapsedMilliseconds) + "ms");
            //        timeCollection.Add(start3.ElapsedMilliseconds);
            //    //} 
            //    i++;
            //    if (i > 30)
            //    {
            //        break;
            //    }
            //}

            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\project\GraphView_partition_temp\log\" + collectionName + "_ShortestPathRandomDistribution_2hop.txt"))
            //{
            //    foreach (var line in timeCollection)
            //    {
            //        file.WriteLine(line);
            //    }
            //}

            //timeCollection.Clear();
            //linesE = File.ReadLines("E:\\dataset\\thsinghua_dataset\\p2p-Gnutella08\\p2p-Gnutella08.txt");
            //src = "0";
            //i = 0;
            //foreach (var node in linesE)
            //{
            //    var edge = node.Split('\t');
            //    src = edge[0].ToString();
            //    String des = edge[1].ToString();
            //    // warm
            //    var tempR = graph0.g().V(src).Out("appear").Out("appear").Out("appear").Values("id").Next();
            //    if (tempR.Count != 0)
            //    {
            //        foreach (var v in tempR)
            //        {
            //            des = v;
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        continue;
            //    }
            //    // warm
            //    start3.Reset();
            //    start3.Start();
            //    ShortestPathTest.GetShortestPath(src, des, graph);
            //    start3.Stop();
            //    Console.WriteLine(collectionName + "(3)" + (start3.ElapsedMilliseconds) + "ms");
            //    timeCollection.Add(start3.ElapsedMilliseconds);
            //    i++;
            //    if (i > 30)
            //    {
            //        break;
            //    }
            //}

            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\project\GraphView_partition_temp\log\" + collectionName + "_ShortestPathRandomDistribution_3hop.txt"))
            //{
            //    foreach (var line in timeCollection)
            //    {
            //        file.WriteLine(line);
            //    }
            //}
        }

        public static void statisticAllThePartitionAndDegreeInformation(String collectionName)
        {
            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
              "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
              "GroupMatch", collectionName, GraphType.GraphAPIOnly, false,
              1, null);
            GraphViewCommand graph = new GraphViewCommand(connection);
            //var result = graph.g().V().Out("appear").Count();
            //foreach(var v in result)
            //{
            //    var a = v;
            //}
            Dictionary<String, HashSet<String>> parSet = new Dictionary<string, HashSet<string>>();
            var result = connection.ExecuteQuery("select * from c where c._isEdgeDoc = true");
            foreach(var t in result)
            {
                var j = (JObject)t;
                var id = j["_vertex_id"].ToString();
                var sinkPartition = j["_edge"][0]["_sinkVPartition"].ToString();
                if(!parSet.ContainsKey(id))
                {
                    parSet.Add(id, new HashSet<string>());
                }
                parSet[id].Add(sinkPartition);
                Console.WriteLine(id + "_" + sinkPartition);
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\project\GraphView_partition_temp\log\" + collectionName + "_PartitionNumberStatistic.txt"))
            {
                foreach (var line in parSet)
                {
                    file.WriteLine(line.Value.Count);
                }
                file.Flush();
            }
        }

        public static void randomDistributionExperimentRunner_2hop(String sampleCollectionName, String collectionName)
        {
            Dictionary<String, long> resultStatistic = new Dictionary<string, long>();
            GraphViewConnection connection0 = new GraphViewConnection("https://graphview.documents.azure.com:443/",
              "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
              "GroupMatch", sampleCollectionName, GraphType.GraphAPIOnly, false,
              1, null);
            GraphViewCommand graph0 = new GraphViewCommand(connection0);
            List<Object> vertexIds0 = new List<object>();

            var start10 = Stopwatch.StartNew();
            var results0 = graph0.g().V().Sample(100).Values("id").Next();

            foreach (var result in results0)
            {
                vertexIds0.Add(result);
            }
            start10.Stop();
            Console.WriteLine("sample vertex " + 1 + "  " + sampleCollectionName + "(0)" + (start10.ElapsedMilliseconds) + "ms");

            var lines = new List<String>();
            var timeCollection = new List<long>();
            var idCollection = new List<object>();

            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
              "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
              "GroupMatch", collectionName, GraphType.GraphAPIOnly, false,
              1, null);
            GraphViewCommand graph = new GraphViewCommand(connection);
            // warm query
            //var re = graph.g().V("9345").Out("appear").Out("appear").Next();
            // warm query
            int i = 1;
            foreach (var id in vertexIds0)
            {
                // warm
                if (i == 50)
                {
                    var tmpD = graph0.g().V().Sample(1).Values("id").Next();
                    Console.WriteLine("Warm query sample 1 vertex finish");
                    // warm
                    var start2 = Stopwatch.StartNew();
                    var results = graph.g().V(id).Out("appear").Out("appear").Next();
                    var c = 0;
                    foreach (var result in results)
                    {
                        c++;
                        var tempResult = result;
                    }
                    start2.Stop();
                    var t = start2.ElapsedMilliseconds;
                    if (c > 0)
                    {
                        timeCollection.Add(t);
                        idCollection.Add(id);
                        Console.WriteLine(collectionName + "(2)" + (t) + "ms");
                        i++;
                        //break;
                    }
                    else
                    {
                        Console.WriteLine("No Out out vertex");
                    }
                } else
                {
                    i++;
                }
                //i++;
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\project\GraphView_partition_temp\log\" + collectionName + "_RandomDistribution2hop.txt"))
            {
                foreach (var line in timeCollection)
                {
                   file.WriteLine(line);
                }
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\project\GraphView_partition_temp\log\" + collectionName + "_RandomDistributionIDCollection2hop.txt"))
            {
                foreach (var line in idCollection)
                {
                    file.WriteLine(line);
                }
            }
        }

        public static void randomDistributionExperimentRunner_3hop(String sampleCollectionName, String collectionName)
        {
            Dictionary<String, long> resultStatistic = new Dictionary<string, long>();
            GraphViewConnection connection0 = new GraphViewConnection("https://graphview.documents.azure.com:443/",
              "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
              "GroupMatch", sampleCollectionName, GraphType.GraphAPIOnly, false,
              1, null);
            GraphViewCommand graph0 = new GraphViewCommand(connection0);
            List<Object> vertexIds0 = new List<object>();

            var start10 = Stopwatch.StartNew();
            var results0 = graph0.g().V().Sample(100).Values("id").Next();

            foreach (var result in results0)
            {
                vertexIds0.Add(result);
            }
            start10.Stop();
            Console.WriteLine("sample vertex " + 1 + "  " + sampleCollectionName + "(0)" + (start10.ElapsedMilliseconds) + "ms");

            var lines = new List<String>();
            var timeCollection = new List<long>();
            var idCollection = new List<object>();

            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
              "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
              "GroupMatch", collectionName, GraphType.GraphAPIOnly, false,
              1, null);
            GraphViewCommand graph = new GraphViewCommand(connection);
            // warm query
            var re = graph.g().V("9345").Out("appear").Out("appear").Next();
            // warm query

            foreach (var id in vertexIds0)
            {
                // warm
                var tmpD = graph0.g().V().Sample(1).Values("id").Next();
                Console.WriteLine("Warm query sample 1 vertex finish");
                // warm
                var start2 = Stopwatch.StartNew();
                var results = graph.g().V(id).Out("appear").Out("appear").Out("appear").Next();

                var c = 0;
                foreach (var result in results)
                {
                    c++;
                    var tempResult = result;
                }

                start2.Stop();

                var t = start2.ElapsedMilliseconds;
                if (c > 0)
                {
                    timeCollection.Add(t);
                    idCollection.Add(id);
                    Console.WriteLine(sampleCollectionName + "(2)" + (t) + "ms");
                    //break;
                }
                else
                {
                    Console.WriteLine("No Out out vertex");
                }
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\project\GraphView_partition_temp\log\" + collectionName + "_RandomDistribution3hop.txt"))
            {
                foreach (var line in timeCollection)
                {
                    file.WriteLine(line);
                }
                file.Flush();
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\project\GraphView_partition_temp\log\" + collectionName + "_RandomDistributionIDCollection3hop.txt"))
            {
                foreach (var line in idCollection)
                {
                    file.WriteLine(line);
                }
                file.Flush();
            }
        }


        public static void randomDistributionExperimentRunner_4hop(String sampleCollectionName, String collectionName)
        {
            Dictionary<String, long> resultStatistic = new Dictionary<string, long>();
            GraphViewConnection connection0 = new GraphViewConnection("https://graphview.documents.azure.com:443/",
              "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
              "GroupMatch", sampleCollectionName, GraphType.GraphAPIOnly, false,
              1, null);
            GraphViewCommand graph0 = new GraphViewCommand(connection0);
            List<Object> vertexIds0 = new List<object>();

            var start10 = Stopwatch.StartNew();
            var results0 = graph0.g().V().Sample(100).Values("id").Next();

            foreach (var result in results0)
            {
                vertexIds0.Add(result);
            }
            start10.Stop();
            Console.WriteLine("sample vertex " + 1 + "  " + sampleCollectionName + "(0)" + (start10.ElapsedMilliseconds) + "ms");

            var lines = new List<String>();
            var timeCollection = new List<long>();
            var idCollection = new List<object>();

            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
              "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
              "GroupMatch", collectionName, GraphType.GraphAPIOnly, false,
              1, null);
            GraphViewCommand graph = new GraphViewCommand(connection);
            // warm query
            var re = graph.g().V("9345").Out("appear").Out("appear").Next();
            // warm query

            foreach (var id in vertexIds0)
            {
                // warm
                var tmpD = graph0.g().V().Sample(1).Values("id").Next();
                Console.WriteLine("Warm query sample 1 vertex finish");
                // warm
                var start2 = Stopwatch.StartNew();
                var results = graph.g().V(id).Out("appear").Out("appear").Out("appear").Out("appear").Next();

                var c = 0;
                foreach (var result in results)
                {
                    c++;
                    var tempResult = result;
                }

                start2.Stop();

                var t = start2.ElapsedMilliseconds;
                if (c > 0)
                {
                    timeCollection.Add(t);
                    idCollection.Add(id);
                    Console.WriteLine(sampleCollectionName + "(2)" + (t) + "ms");
                    //break;
                }
                else
                {
                    Console.WriteLine("No Out out vertex");
                }
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\project\GraphView_partition_temp\log\" + collectionName + "_RandomDistribution4hop.txt"))
            {
                foreach (var line in timeCollection)
                {
                    file.WriteLine(line);
                }
                file.Flush();
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\project\GraphView_partition_temp\log\" + collectionName + "_RandomDistributionIDCollection4hop.txt"))
            {
                foreach (var line in idCollection)
                {
                    file.WriteLine(line);
                }
                file.Flush();
            }
        }

        public static void repartition(String col1, String col2)
        {
            GraphViewConnection connection1 = new GraphViewConnection("https://graphview.documents.azure.com:443/",
         "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
         "GroupMatch", col1, GraphType.GraphAPIOnly, false,
               1, "name");
            GraphViewConnection.partitionNum = 100;
            connection1.EdgeSpillThreshold = 1;
            GraphViewCommand cmd = new GraphViewCommand(connection1);

       //     GraphViewConnection connection2 = GraphViewConnection.ResetGraphAPICollection("https://graphview.documents.azure.com:443/",
       //"MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
       //"GroupMatch", col2,
       //false, 1, "name");
       //     connection2.EdgeSpillThreshold = 1;
       //     connection2.AssignSeenDesNotSeenSrcToBalance = true;
       //     GraphViewConnection.partitionLoad = new int[GraphViewConnection.partitionNum];
       //     connection2.repartitionByBFS(connection1);
       //     connection2.getMetricsOfGraphPartition();

       //            GraphViewConnection connection2 = GraphViewConnection.ResetGraphAPICollection("https://graphview.documents.azure.com:443/",
       //"MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
       //"GroupMatch", col2,
       //false, 1, "name");
            connection1.EdgeSpillThreshold = 1;
            connection1.AssignSeenDesNotSeenSrcToBalance = true;
            GraphViewConnection.partitionLoad = new int[GraphViewConnection.partitionNum];
            connection1.repartitionByBFS(connection1);
            //connection1.getMetricsOfGraphPartition();
        }
        public static void queryComparePartitionInCondition(String collectionName)
        {
            var queryOptions = new FeedOptions
            {
                EnableCrossPartitionQuery = true,
                MaxItemCount = 100000,
                EnableScanInQuery = true,
            };

            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
               "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
               "GroupMatch", collectionName, GraphType.GraphAPIOnly, false,
               1, null);
            GraphViewCommand graph = new GraphViewCommand(connection);
            //graph.OutputFormat = OutputFormat.GraphSON;
            // (0) warm query
            var vertexIds = new StringBuilder();
            var partitionIds = new HashSet<String>();
            var partitionIdStr = new StringBuilder();

            for (int p = 100; p > 99; p--)
            {
                for (int i = 0; i < 100; i++)
                {
                    //vertexIds.Add(p + "-" + i);
                    var id = p + "-" + i;
                    vertexIds.Append("'" + id + "',");
                    if (!partitionIds.Contains(p.ToString()))
                    {
                        partitionIds.Add(p.ToString());
                        partitionIdStr.Append("'" + p + "',");
                    }
                }
            }
            vertexIds.Remove(vertexIds.Length - 1, 1);
            partitionIdStr.Remove(partitionIdStr.Length - 1, 1);

            var start0 = Stopwatch.StartNew();
            //var results = graph.g().V(vertexIds).Next();
            var results0 = connection.ExecuteQuery("SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in (" + partitionIdStr + "))", queryOptions);

            foreach (var result in results0)
            {
                //Console.WriteLine(result);
                var t = result;
            }

            start0.Stop();
            Console.WriteLine("warm query" + (start0.ElapsedMilliseconds) + "ms");

            // (1) query 1 partition
            //List<Object> vertexIds = new List<object>();
            //var vertexIds = new StringBuilder();
            //var partitionIds = new HashSet<String>();
            //var partitionIdStr = new StringBuilder();
            vertexIds.Clear();
            partitionIdStr.Clear();
            partitionIds.Clear();

            for (int p = 1; p < 100; p++)
            {
                for (int i = 0; i < 1; i++)
                {
                    //vertexIds.Add(p + "-" + i);
                    var id = p + "-" + i;
                    vertexIds.Append("'" + id + "',");
                    if (!partitionIds.Contains(p.ToString()))
                    {
                        partitionIds.Add(p.ToString());
                        partitionIdStr.Append("'" + p + "',");
                    }
                }
            }
            vertexIds.Remove(vertexIds.Length - 1, 1);
            partitionIdStr.Remove(partitionIdStr.Length - 1, 1);

            var script1 = "SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in (" + partitionIdStr + "))";
            var start1 = Stopwatch.StartNew();
            //var results = graph.g().V(vertexIds).Next();
            var results = connection.ExecuteQuery(script1, queryOptions);

            foreach (var result in results)
            {
                //Console.WriteLine(result);
                var t = result;
            }

            start1.Stop();
            Console.WriteLine("have partition condition partition count" + 100 + "  " + collectionName + "(0)" + (start1.ElapsedMilliseconds) + "ms");
            // (2)
            vertexIds.Clear();
            partitionIdStr.Clear();
            partitionIds.Clear();

            for (int p = 1; p < 100; p++)
            {
                for (int i = 0; i < 1; i++)
                {
                    //vertexIds.Add(p + "-" + i);
                    var id = p + "-" + i;
                    vertexIds.Append("'" + id + "',");
                    if (!partitionIds.Contains(p.ToString()))
                    {
                        partitionIds.Add(p.ToString());
                        partitionIdStr.Append("'" + p + "',");
                    }
                }
            }
            vertexIds.Remove(vertexIds.Length - 1, 1);
            partitionIdStr.Remove(partitionIdStr.Length - 1, 1);

            var script2 = "SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + "))";
            var start2 = Stopwatch.StartNew();
            //var results = graph.g().V(vertexIds).Next();
            results = connection.ExecuteQuery(script1, queryOptions);

            foreach (var result in results)
            {
                //Console.WriteLine(result);
                var t = result;
            }

            start2.Stop();
            Console.WriteLine("no partition condition partition count" + 100 + "  " + collectionName + "(0)" + (start2.ElapsedMilliseconds) + "ms");
        }

        public static void querySpecificIDsListUseSystemCall_SamePartitionCount_DiffVertexCount(String collectionName)
        {
            var queryOptions = new FeedOptions
            {
                EnableCrossPartitionQuery = true,
                MaxItemCount = 100000,
                EnableScanInQuery = true,
            };

            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
               "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
               "GroupMatch", collectionName, GraphType.GraphAPIOnly, false,
               1, null);
            GraphViewCommand graph = new GraphViewCommand(connection);
            //graph.OutputFormat = OutputFormat.GraphSON;
            // (0) warm query
            var vertexIds = new StringBuilder();
            var partitionIds = new HashSet<String>();
            var partitionIdStr = new StringBuilder();

            for (int p = 1; p < 2; p++)
            {
                for (int i = 0; i < 1; i++)
                {
                    //vertexIds.Add(p + "-" + i);
                    var id = p + "-" + i;
                    vertexIds.Append("'" + id + "',");
                    if (!partitionIds.Contains(p.ToString()))
                    {
                        partitionIds.Add(p.ToString());
                        partitionIdStr.Append("'" + p + "',");
                    }
                }
            }
            vertexIds.Remove(vertexIds.Length - 1, 1);
            partitionIdStr.Remove(partitionIdStr.Length - 1, 1);

            var start0 = Stopwatch.StartNew();
            //var results = graph.g().V(vertexIds).Next();
            var results0 = connection.ExecuteQuery("SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in (" + partitionIdStr + "))", queryOptions);

            foreach (var result in results0)
            {
                //Console.WriteLine(result);
                var t = result;
            }

            start0.Stop();
            Console.WriteLine("warm query" + (start0.ElapsedMilliseconds) + "ms");
            // (0) query 1
            vertexIds.Clear();
            partitionIdStr.Clear();
            partitionIds.Clear();

            for (int p = 1; p < 100; p++)
            {
                for (int i = 0; i < 1; i++)
                {
                    //vertexIds.Add(p + "-" + i);
                    var id = p + "-" + i;
                    vertexIds.Append("'" + id + "',");
                    if (!partitionIds.Contains(p.ToString()))
                    {
                        partitionIds.Add(p.ToString());
                        partitionIdStr.Append("'" + p + "',");
                    }
                }
            }
            vertexIds.Remove(vertexIds.Length - 1, 1);
            partitionIdStr.Remove(partitionIdStr.Length - 1, 1);

            var start10 = Stopwatch.StartNew();
            //var results = graph.g().V(vertexIds).Next();
            var results = connection.ExecuteQuery("SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in (" + partitionIdStr + "))", queryOptions);

            foreach (var result in results)
            {
                //Console.WriteLine(result);
                var t = result;
            }

            start10.Stop();
            Console.WriteLine("node count" + 1 + "  " + collectionName + "(0)" + (start10.ElapsedMilliseconds) + "ms");
            // (1) query 1 partition
            //List<Object> vertexIds = new List<object>();
            //var vertexIds = new StringBuilder();
            //var partitionIds = new HashSet<String>();
            //var partitionIdStr = new StringBuilder();
            vertexIds.Clear();
            partitionIdStr.Clear();
            partitionIds.Clear();

            for (int p = 1; p < 2; p++)
            {
                for (int i = 0; i < 30; i++)
                {
                    //vertexIds.Add(p + "-" + i);
                    var id = p + "-" + i;
                    vertexIds.Append("'" + id + "',");
                    if (!partitionIds.Contains(p.ToString()))
                    {
                        partitionIds.Add(p.ToString());
                        partitionIdStr.Append("'" + p + "',");
                    }
                }
            }
            vertexIds.Remove(vertexIds.Length - 1, 1);
            partitionIdStr.Remove(partitionIdStr.Length - 1, 1);

            var start1 = Stopwatch.StartNew();
            //var results = graph.g().V(vertexIds).Next();
            results = connection.ExecuteQuery("SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in (" + partitionIdStr + "))", queryOptions);

            foreach (var result in results)
            {
                //Console.WriteLine(result);
                var t = result;
            }

            start1.Stop();
            Console.WriteLine("node count" + 30 + "  " + collectionName + "(0)" + (start1.ElapsedMilliseconds) + "ms");

            // (2) 2 p
            vertexIds.Clear();
            partitionIdStr.Clear();
            partitionIds.Clear();
            for (int p = 1; p < 2; p++)
            {
                for (int i = 0; i < 50; i++)
                {
                    //vertexIds.Add(p + "-" + i);
                    var id = p + "-" + i;
                    vertexIds.Append("'" + id + "',");
                    if (!partitionIds.Contains(p.ToString()))
                    {
                        partitionIds.Add(p.ToString());
                        partitionIdStr.Append("'" + p + "',");
                    }
                }
            }
            vertexIds.Remove(vertexIds.Length - 1, 1);
            partitionIdStr.Remove(partitionIdStr.Length - 1, 1);

            var start2 = Stopwatch.StartNew();
            //var results = graph.g().V(vertexIds).Next();
            results = connection.ExecuteQuery("SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in (" + partitionIdStr + "))", queryOptions);

            foreach (var result in results)
            {
                //Console.WriteLine(result);
                var t = result;
            }

            start2.Stop();
            Console.WriteLine("node count" + 50 + "  " + collectionName + "(1)" + (start2.ElapsedMilliseconds) + "ms");

            // (3) 10 partition
            vertexIds.Clear();
            partitionIdStr.Clear();
            partitionIds.Clear();
            for (int p = 1; p < 2; p++)
            {
                for (int i = 0; i < 100; i++)
                {
                    //vertexIds.Add(p + "-" + i);
                    var id = p + "-" + i;
                    vertexIds.Append("'" + id + "',");
                    if (!partitionIds.Contains(p.ToString()))
                    {
                        partitionIds.Add(p.ToString());
                        partitionIdStr.Append("'" + p + "',");
                    }
                }
            }
            vertexIds.Remove(vertexIds.Length - 1, 1);
            partitionIdStr.Remove(partitionIdStr.Length - 1, 1);

            var start3 = Stopwatch.StartNew();
            //var results = graph.g().V(vertexIds).Next();
            results = connection.ExecuteQuery("SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in (" + partitionIdStr + "))", queryOptions);

            foreach (var result in results)
            {
                //Console.WriteLine(result);
                var t = result;
            }

            start3.Stop();
            Console.WriteLine("node count" + 100 + "  " + collectionName + "(2)" + (start3.ElapsedMilliseconds) + "ms");   
        }

        public static void bulkInsertUtils(String collectionName, int partitionCount, List<String> vertex)
        {
            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
                  "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
                  "GroupMatch", collectionName, GraphType.GraphAPIOnly, false, 1, "name");
            connection.initPartitionConfig(partitionCount);
            connection.EdgeSpillThreshold = 1;
            GraphViewConnection.useHashPartitionWhenCreateDoc = false;
            GraphViewConnection.useFakePartitionWhenCreateDoc = true;
            GraphViewConnection.useBulkInsert = true;
            GraphViewCommand cmd = new GraphViewCommand(connection);
            HashSet<String> nodeIdSet = new HashSet<String>();
            BulkInsertUtils blk = new BulkInsertUtils(GraphViewConnection.partitionNum);
            blk.initBulkInsertUtilsForParseData(GraphViewConnection.partitionNum, vertex.Count(), connection);

            foreach (var lineE in vertex)
            {
                blk.stringBufferList.Add(lineE);
            }
            blk.startParseThread();
            blk.parseDataCountDownLatch.Await();
            blk.initAndStartInsertNodeStringCMD();
            blk.insertNodeCountDownLatch.Await();
            blk.initAndStartInsertEdgeStringCMD();
            GraphViewConnection.bulkInsertUtil.startParseThread();
        }

        public static List<String> getSameVertexDiffPartitionList(int partitionNum, int sumVertexCount)
        {
            var vertex = new List<String>();

            // 1 p
            vertex.Clear();
            var partitionCount = 1;

            for (int i = 0; i < partitionCount; i++)
            {
                for (int j = 0; j < 1000 / partitionCount; j++)
                {
                    var v = i + "\t" + j;
                    vertex.Add(v);
                }
            }

            return vertex;
        }

        public static void insertSameVertexCountDiffPartitionCount(String collectionName)
        {
            // test for 1, 10, 30, 100, 200, 500, 1000 partition so the same vertex is 1000 vertex count
            // 1
            var partitionCount = 1;
            var vertex = getSameVertexDiffPartitionList(1, 1000);
            bulkInsertUtils(collectionName, partitionCount, vertex);

            // 10
            partitionCount = 10;
            vertex = getSameVertexDiffPartitionList(10, 1000);
            bulkInsertUtils(collectionName, partitionCount, vertex);
            // 30 
            partitionCount = 30;
            vertex = getSameVertexDiffPartitionList(30, 1000);
            bulkInsertUtils(collectionName, partitionCount, vertex);
            // 100
            partitionCount = 100;
            vertex = getSameVertexDiffPartitionList(100, 1000);
            bulkInsertUtils(collectionName, partitionCount, vertex);
            // 200
            partitionCount = 200;
            vertex = getSameVertexDiffPartitionList(200, 1000);
            bulkInsertUtils(collectionName, partitionCount, vertex);
            // 500
            partitionCount = 500;
            vertex = getSameVertexDiffPartitionList(500, 1000);
            bulkInsertUtils(collectionName, partitionCount, vertex);
            // 1000
            partitionCount = 1000;
            vertex = getSameVertexDiffPartitionList(1000, 1000);
            bulkInsertUtils(collectionName, partitionCount, vertex);
        }

        public static void querySpecificIDsListUseSystemCall_SamePartitionCount_DiffVertexCount_ExtremeVertexCount(String collectionName)
        {
            var queryOptions = new FeedOptions
            {
                EnableCrossPartitionQuery = true,
                MaxItemCount = 100000,
                EnableScanInQuery = true,
            };

            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
               "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
               "GroupMatch", collectionName, GraphType.GraphAPIOnly, false,
               1, null);
            GraphViewCommand graph = new GraphViewCommand(connection);
            //graph.OutputFormat = OutputFormat.GraphSON;
            // (0) warm query
            var vertexIds = new StringBuilder();
            var partitionIds = new HashSet<String>();
            var partitionIdStr = new StringBuilder();
                for (int p = 0; p < 100; p++)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        //vertexIds.Add(p + "-" + i);
                        var id = p + "-" + i;
                        vertexIds.Append("'" + id + "',");
                        if (!partitionIds.Contains(p.ToString()))
                        {
                            partitionIds.Add(p.ToString());
                            partitionIdStr.Append("'" + p + "',");
                        }
                    }
                }
            vertexIds.Remove(vertexIds.Length - 1, 1);
            partitionIdStr.Remove(partitionIdStr.Length - 1, 1);

            var script0 = "SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in (" + partitionIdStr + "))";
            var start0 = Stopwatch.StartNew();
            //var results = graph.g().V(vertexIds).Next();
            var results0 = connection.ExecuteQueryWithoutToList(script0, queryOptions);

            foreach (var result in results0)
            {
                //Console.WriteLine(result);
                var t = result;
            }

            start0.Stop();
            Console.WriteLine("warm query" + (start0.ElapsedMilliseconds) + "ms");

            // (1) query 100 partition
            vertexIds.Clear();
            partitionIdStr.Clear();
            partitionIds.Clear();

            var stepList = new List<int>() {1, 10, 30, 100, 200, 500, 1000};
            //var stepList = new List<int>() { 1, 10, 30 };

            var timeCollection = new List<String>();
            foreach (var step in stepList)
            {
                vertexIds.Clear();
                partitionIdStr.Clear();
                for (int p = 0; p < step; p++)
                {
                    for (int i = 0; i < 1000/step; i++)
                    {
                        //vertexIds.Add(p + "-" + i);
                        var id = p + "-" + i;
                        vertexIds.Append("'" + id + "',");
                        if (!partitionIds.Contains(p.ToString()))
                        {
                            partitionIds.Add(p.ToString());
                            partitionIdStr.Append("'" + p + "',");
                        }
                    }
                }

                vertexIds.Remove(vertexIds.Length - 1, 1);
                partitionIdStr.Remove(partitionIdStr.Length - 1, 1);
                var script1 = "SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in (" + partitionIdStr + "))";

                var start1 = Stopwatch.StartNew();
                //var results = graph.g().V(vertexIds).Next();
                var results = connection.ExecuteQueryWithoutToList(script1, queryOptions);

                foreach (var result in results)
                {
                    //Console.WriteLine(result);
                    var t = result;
                }

                start1.Stop();
                timeCollection.Add(step + "," + start1.ElapsedMilliseconds);
                Console.WriteLine("partition count " + collectionName + "(0)" + (start1.ElapsedMilliseconds) + "ms");
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\project\GraphView_partition_temp\log\" + collectionName + "_DiffPartition.txt"))
            {
                foreach (var line in timeCollection)
                {
                    file.WriteLine(line);
                }
            }
        }

        public static void querySpecificIDsListUseSystemCall_DiffVertexCount_SamePartitionNum(String collectionName)
        {
            var queryOptions = new FeedOptions
            {
                EnableCrossPartitionQuery = true,
                MaxItemCount = 100000,
                EnableScanInQuery = true,
            };

            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
               "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
               "GroupMatch", collectionName, GraphType.GraphAPIOnly, false,
               1, null);
            GraphViewCommand graph = new GraphViewCommand(connection);
            //graph.OutputFormat = OutputFormat.GraphSON;
            // (0) warm query
            var vertexIds = new StringBuilder();
            var partitionIds = new HashSet<String>();
            var partitionIdStr = new StringBuilder();

            for (int p = 100; p > 99; p--)
            {
                for (int i = 0; i < 1; i++)
                {
                    //vertexIds.Add(p + "-" + i);
                    var id = p + "-" + i;
                    vertexIds.Append("'" + id + "',");
                    if (!partitionIds.Contains(p.ToString()))
                    {
                        partitionIds.Add(p.ToString());
                        partitionIdStr.Append("'" + p + "',");
                    }
                }
            }
            vertexIds.Remove(vertexIds.Length - 1, 1);
            partitionIdStr.Remove(partitionIdStr.Length - 1, 1);

            var script0 = "SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in (" + partitionIdStr + "))";
            var start0 = Stopwatch.StartNew();
            //var results = graph.g().V(vertexIds).Next();
            var results0 = connection.ExecuteQueryWithoutToList(script0, queryOptions);

            foreach (var result in results0)
            {
                //Console.WriteLine(result);
                var t = result;
            }

            start0.Stop();
            Console.WriteLine("warm query" + (start0.ElapsedMilliseconds) + "ms");

            // (1) query 1 partition
            vertexIds.Clear();
            partitionIdStr.Clear();
            partitionIds.Clear();

            var queryVertexStep = new List<int>() {1, 1,2,10,30,50, 100, 200, 250, 300, 500, 800, 1000, 2000, 3000};
            var timeCollection = new List<String>();
            foreach(var step in queryVertexStep) {
                vertexIds.Clear();
                for (int p = 0; p < 1; p++)
                {
                    for (int i = 0; i < step; i++)
                    {
                        var id = p + "-" + i;
                        vertexIds.Append("'" + id + "',");
                    }
                }

                vertexIds.Remove(vertexIds.Length - 1, 1);
                Console.WriteLine("in loop query");
                var script1 = "SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in ('0'))";

                var start1 = Stopwatch.StartNew();
                var results = connection.ExecuteQueryWithoutToList(script1, queryOptions);

                foreach (var result in results)
                {
                    //Console.WriteLine(result);
                    var t = result;
                }

                start1.Stop();
                Console.WriteLine("vertex count  " + step + "  " + collectionName + "(0)" + (start1.ElapsedMilliseconds) + "ms");
                timeCollection.Add(step + "," + start1.ElapsedMilliseconds);
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"E:\project\GraphView_partition_temp\log\" + collectionName + "_DiffVertexIn1Partition.txt"))
            {
                foreach (var line in timeCollection)
                {
                    file.WriteLine(line);
                }
            }
        }

        public static void querySpecificIDsListUseSystemCall_SameVertexCount_DiffPartitionNum(String collectionName)
        {
            var queryOptions = new FeedOptions
            {
                EnableCrossPartitionQuery = true,
                MaxItemCount = 100000,
                EnableScanInQuery = true,
            };

            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
               "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
               "GroupMatch", collectionName, GraphType.GraphAPIOnly, false,
               1, null);
            GraphViewCommand graph = new GraphViewCommand(connection);
            //graph.OutputFormat = OutputFormat.GraphSON;
            // (0) warm query
            var vertexIds = new StringBuilder();
            var partitionIds = new HashSet<String>();
            var partitionIdStr = new StringBuilder();

            for (int p = 100; p > 99; p--)
            {
                for (int i = 0; i < 1; i++)
                {
                    //vertexIds.Add(p + "-" + i);
                    var id = p + "-" + i;
                    vertexIds.Append("'" + id + "',");
                    if (!partitionIds.Contains(p.ToString()))
                    {
                        partitionIds.Add(p.ToString());
                        partitionIdStr.Append("'" + p + "',");
                    }
                }
            }
            vertexIds.Remove(vertexIds.Length - 1, 1);
            partitionIdStr.Remove(partitionIdStr.Length - 1, 1);

            var script0 = "SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in (" + partitionIdStr + "))";
            var start0 = Stopwatch.StartNew();
            //var results = graph.g().V(vertexIds).Next();
            var results0 = connection.ExecuteQueryWithoutToList(script0, queryOptions);

            foreach (var result in results0)
            {
                //Console.WriteLine(result);
                var t = result;
            }

            start0.Stop();
            Console.WriteLine("warm query" + (start0.ElapsedMilliseconds) + "ms");

            // (1) query 1 partition
            //List<Object> vertexIds = new List<object>();
            //var vertexIds = new StringBuilder();
            //var partitionIds = new HashSet<String>();
            //var partitionIdStr = new StringBuilder();
            vertexIds.Clear();
            partitionIdStr.Clear();
            partitionIds.Clear();

            for (int p = 1; p < 2; p++)
            {
                for (int i = 0; i < 30; i++)
                {
                    //vertexIds.Add(p + "-" + i);
                    var id = p + "-" + i;
                    vertexIds.Append("'" + id + "',");
                    if (!partitionIds.Contains(p.ToString()))
                    {
                        partitionIds.Add(p.ToString());
                        partitionIdStr.Append("'" + p + "',");
                    }
                }
            }
            vertexIds.Remove(vertexIds.Length - 1, 1);
            partitionIdStr.Remove(partitionIdStr.Length - 1, 1);
            var script1 = "SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in (" + partitionIdStr + "))";

            var start1 = Stopwatch.StartNew();
            //var results = graph.g().V(vertexIds).Next();
            var results = connection.ExecuteQueryWithoutToList(script1, queryOptions);

            foreach (var result in results)
            {
                //Console.WriteLine(result);
                var t = result;
            }

            start1.Stop();
            Console.WriteLine("partition count" + 1 + "  " + collectionName + "(0)" + (start1.ElapsedMilliseconds) + "ms");

            // (2) 2 p
            vertexIds.Clear();
            partitionIdStr.Clear();
            partitionIds.Clear();
            for (int p = 1; p < 3; p++)
            {
                for (int i = 0; i < 16; i++)
                {
                    //vertexIds.Add(p + "-" + i);
                    var id = p + "-" + i;
                    vertexIds.Append("'" + id + "',");
                    if (!partitionIds.Contains(p.ToString()))
                    {
                        partitionIds.Add(p.ToString());
                        partitionIdStr.Append("'" + p + "',");
                    }
                }
            }
            vertexIds.Remove(vertexIds.Length - 1, 1);
            partitionIdStr.Remove(partitionIdStr.Length - 1, 1);
            var script2 = script0 = "SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in (" + partitionIdStr + "))";

            var start2 = Stopwatch.StartNew();
            //var results = graph.g().V(vertexIds).Next();
            results = connection.ExecuteQueryWithoutToList(script2, queryOptions);

            foreach (var result in results)
            {
                //Console.WriteLine(result);
                var t = result;
            }

            start2.Stop();
            Console.WriteLine("partition count" + 2 + "  " + collectionName + "(1)" + (start2.ElapsedMilliseconds) + "ms");

            // (3) 10 partition
            vertexIds.Clear();
            partitionIdStr.Clear();
            partitionIds.Clear();
            for (int p = 1; p < 11; p++)
            {
                for (int i = 0; i < 3; i++)
                {
                    //vertexIds.Add(p + "-" + i);
                    var id = p + "-" + i;
                    vertexIds.Append("'" + id + "',");
                    if (!partitionIds.Contains(p.ToString()))
                    {
                        partitionIds.Add(p.ToString());
                        partitionIdStr.Append("'" + p + "',");
                    }
                }
            }
            vertexIds.Remove(vertexIds.Length - 1, 1);
            partitionIdStr.Remove(partitionIdStr.Length - 1, 1);
            var script3 = "SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in (" + partitionIdStr + "))";

            var start3 = Stopwatch.StartNew();
            //var results = graph.g().V(vertexIds).Next();
            results = connection.ExecuteQueryWithoutToList(script3, queryOptions);

            foreach (var result in results)
            {
                //Console.WriteLine(result);
                var t = result;
            }

            start3.Stop();
            Console.WriteLine("partition count" + 10 + "  " + collectionName + "(2)" + (start3.ElapsedMilliseconds) + "ms");
            // (4) 30 partition

            vertexIds.Clear();
            partitionIdStr.Clear();
            partitionIds.Clear();
            for (int p = 1; p < 31; p++)
            {
                for (int i = 0; i < 1; i++)
                {
                    //vertexIds.Add(p + "-" + i);
                    var id = p + "-" + i;
                    vertexIds.Append("'" + id + "',");
                    if (!partitionIds.Contains(p.ToString()))
                    {
                        partitionIds.Add(p.ToString());
                        partitionIdStr.Append("'" + p + "',");
                    }
                }
            }
            vertexIds.Remove(vertexIds.Length - 1, 1);
            partitionIdStr.Remove(partitionIdStr.Length - 1, 1);
            var script4 = "SELECT N_3 FROM Node N_3  WHERE IS_DEFINED(N_3._isEdgeDoc) = false AND(N_3.id in (" + vertexIds + ")) AND (N_3._partition in (" + partitionIdStr + "))";

            var start4 = Stopwatch.StartNew();
            //var results = graph.g().V(vertexIds).Next();
            results = connection.ExecuteQueryWithoutToList(script4, queryOptions);

            foreach (var result in results)
            {
                //Console.WriteLine(result);
                var t = result;
            }

            start4.Stop();
            Console.WriteLine("partition count" + 30 + "  " + collectionName + "(4)" + (start4.ElapsedMilliseconds) + "ms");
        }

        public static void querySpecificIDsList(String collectionName)
        {
            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
               "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
               "GroupMatch", collectionName, GraphType.GraphAPIOnly, false,
               1, null);
            GraphViewCommand graph = new GraphViewCommand(connection);
            //graph.OutputFormat = OutputFormat.GraphSON;
            List<Object> vertexIds0 = new List<object>();
            for (int p = 1; p < 2; p++)
            {
                for (int i = 0; i < 30; i++)
                {
                    vertexIds0.Add(p + "-" + i);
                }
            }
            var start10 = Stopwatch.StartNew();
            var results0 = graph.g().V(vertexIds0).Next();

            foreach (var result in results0)
            {
                Console.WriteLine(result);
            }
            start10.Stop();
            Console.WriteLine("warm query " + 1 + "  " + collectionName + "(0)" + (start10.ElapsedMilliseconds) + "ms");

            // (1) query 1 partition
            List<Object> vertexIds = new List<object>();
            for (int p = 1; p < 2; p++) { 
                for (int i = 0; i < 30; i++)
                {
                    vertexIds.Add(p + "-" + i);
                }
            }
            var start1 = Stopwatch.StartNew();
            var results = graph.g().V(vertexIds).Next();

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            start1.Stop();
            Console.WriteLine("partition count" + 1 + "  " + collectionName + "(0)" + (start1.ElapsedMilliseconds) + "ms");

            // (2) query 10 partition

            vertexIds.Clear();
            for (int p = 0; p < 10; p++)
            {
                for (int i = 1; i < 4; i++)
                {
                    vertexIds.Add(p + "-" + i);
                }
            }
            var start2 = Stopwatch.StartNew();
            results = graph.g().V(vertexIds).Next();

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            start2.Stop();
            Console.WriteLine("partition count" + 10 + "  " + collectionName + "(1)" + (start2.ElapsedMilliseconds) + "ms");

            // (3) query 30 partition

            vertexIds.Clear();
            for (int p = 0; p < 30; p++)
            {
                for (int i = 1; i < 2; i++)
                {
                    vertexIds.Add(p + "-" + i);
                }
            }
            var start3 = Stopwatch.StartNew();
            results = graph.g().V(vertexIds).Next();

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            start3.Stop();
            Console.WriteLine("partition count" + 30 + "  " + collectionName + "(2)" + (start3.ElapsedMilliseconds) + "ms");

            // (4) query 5 partition
            vertexIds.Clear();
            for (int p = 0; p < 5; p++)
            {
                for (int i = 1; i < 7; i++)
                {
                    vertexIds.Add(p + "-" + i);
                }
            }
            var start5 = Stopwatch.StartNew();
            results = graph.g().V(vertexIds).Next();

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            start5.Stop();
            Console.WriteLine("partition count" + 5 + "  " + collectionName + "(3)" + (start5.ElapsedMilliseconds) + "ms");

            // (5) query 2 partition
            vertexIds.Clear();
            for (int p = 0; p < 2; p++)
            {
                for (int i = 1; i < 16; i++)
                {
                    vertexIds.Add(p + "-" + i);
                }
            }
            var start2p = Stopwatch.StartNew();
            results = graph.g().V(vertexIds).Next();

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            start2p.Stop();
            Console.WriteLine("partition count" + 2 + "  " + collectionName + "(4)" + (start2p.ElapsedMilliseconds) + "ms");
        }

        public static void getSampleOutVertex(GraphViewCommand graph, String src, List<Object> sample)
        {
            
            var hop_1 = graph.g().V(src).Out("appear").Values("id").Next();
            int c = 0;
            int step = 3;
            foreach (var h1 in hop_1)
            {
                if (c < step)
                {
                    sample.Add(h1);
                }
                else
                {
                    break;
                }
                c++;
            }

            c = 0;
            var hop_2 = graph.g().V(src).Out("appear").Out("appear").Values("id").Next();
            foreach (var h2 in hop_2)
            {
                if (c < step)
                {
                    sample.Add(h2);
                }
                else
                {
                    break;
                }
                c++;
            }

            c = 0;
            var hop_3 = graph.g().V(src).Out("appear").Out("appear").Out("appear").Values("id").Next();
            foreach (var h3 in hop_3)
            {
                if (c < step)
                {
                    sample.Add(h3);
                }
                else
                {
                    break;
                }
                c++;
            }
        }

        public static void partitionQueryTestCommon(String sampleCollection, String collectionName)
        {
            Console.WriteLine("[##################################################start warm query]");
            Console.WriteLine(collectionName + "start test");
            GraphViewConnection connection0 = new GraphViewConnection("https://graphview.documents.azure.com:443/",
             "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
             "GroupMatch", sampleCollection, GraphType.GraphAPIOnly, false,
             1, null);

            GraphViewCommand graph0 = new GraphViewCommand(connection0);
            var sample = new List<Object>();
            var resultsS = graph0.g().V().Sample(10).Next();

            foreach (var result in resultsS)
            {
                sample.Add(result.Replace("v", "").Replace("[", "").Replace("]", ""));
            }
            Console.WriteLine("[##################################################finish warm query]");
           // (1) FindNeighbours(FN): finds the neighbours of all nodes.
            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
               "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
               "GroupMatch", collectionName, GraphType.GraphAPIOnly, false,
               1, null);

            GraphViewCommand graph = new GraphViewCommand(connection);


            //graph.OutputFormat = OutputFormat.GraphSON;
            //var start1 = Stopwatch.StartNew();
            ////var results = graph.g().V().Next();
            //var results = graph.g().V().Sample(10).Out("appear").Out("appear").Next();

            //foreach (var result in results)
            //{
            //    //Console.WriteLine(result);
            //}
            //start1.Stop();
            //Console.WriteLine(collectionName + " warm query (0)" + (start1.ElapsedMilliseconds) + "ms");

            //graph.OutputFormat = OutputFormat.GraphSON;
            //Console.WriteLine("Start query1");
            //var start1 = Stopwatch.StartNew();
            //var results = graph.g().V().Sample(10).Out("appear").Next();
            ////var results = graph.g().V().Sample(10).Out().Next();

            //foreach (var result in results)
            //{
            //    //Console.WriteLine(result);
            //}
            //start1.Stop();
            //Console.WriteLine(collectionName + "(1)" + (start1.ElapsedMilliseconds) + "ms");

            // (2) FindAdjacentNodes (FA): finds the 3-hop adjacent
            var start2 = Stopwatch.StartNew();
            var results = graph.g().V(sample[6]).Out("appear").Out("appear").Next();
            //results = graph.g().V().Sample(10).Out().Out().Next();

            foreach (var result in results)
            {
                //var a = result;
                //Console.WriteLine(result);
            }
            start2.Stop();
            var t = start2.ElapsedMilliseconds;
            Console.WriteLine(collectionName + "(2)" + (t) + "ms");
            // (3) Shortest Path: FindShortestPath (FS): finds the shortest path between the first node and 100 randomly picked nodes.

            //var linesE = File.ReadLines("E:\\dataset\\thsinghua_dataset\\cit_network\\cit-HepTh.txt\\Cit-HepTh.txt");
            ////String src = sample[0].ToString();
            //String src = "1001";
           
            //sample.RemoveAt(0);
            //int i = 0;
            ////foreach (var node in linesE)
            ////{
            ////    var edge = node.Split('\t');
            ////    src = edge[0].ToString();
            ////    String des = edge[1].ToString();
            ////    //ShortestPathTest.GetShortestPath(edge[0], edge[1], graph);
            ////    ShortestPathTest.GetShortestPath(src, des, graph);

            ////    // src = des;
            ////    i++;
            ////    if (i > 0)
            ////    {
            ////        break;
            ////    }
            ////}

            //sample.Clear();
            //getSampleOutVertex(graph0, src, sample);

            //var start3 = Stopwatch.StartNew();
            //foreach (var v in sample)
            //{
            //    ShortestPathTest.GetShortestPath(src, v.ToString(), graph);
            //}

            //start3.Stop();
            //Console.WriteLine(collectionName + "(3)" + (start3.ElapsedMilliseconds) + "ms");
            //Console.WriteLine(collectionName + "end test");
        }

        //   public static void insertCitData()
        //   {
        //          GraphViewConnection connection = GraphViewConnection.ResetGraphAPICollection("https://graphview.documents.azure.com:443/",
        //"MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
        //"GroupMatch", "CitAllDataHashPartition", 
        //false, 1, "id");
        //       connection.EdgeSpillThreshold = 1;
        //       GraphViewConnection.useHashPartitionWhenCreateDoc = true;
        //       GraphViewConnection.useBulkInsert = true;
        //       GraphViewCommand cmd = new GraphViewCommand(connection);
        //       HashSet<String> nodeIdSet = new HashSet<String>();

        //       int c = 1;
        //       var linesE = File.ReadLines("D:\\dataset\\thsinghua_dataset\\cit_network\\cit-HepTh.txt\\Cit-HepTh.txt");
        //       foreach (var lineE in linesE)
        //       {
        //           if (c > 4)
        //           {
        //               var split = lineE.Split('\t');
        //               var src = split[0];
        //               var des = split[1];

        //               if (!nodeIdSet.Contains(src))
        //               {
        //                   cmd.CommandText = "g.addV('id', '" + src + "').property('name', '" + src + "').next()";
        //                   cmd.Execute();
        //                   nodeIdSet.Add(src);
        //               }

        //               if (!nodeIdSet.Contains(des))
        //               {
        //                   cmd.CommandText = "g.addV('id', '" + des + "').property('name', '" + des + "').next()";
        //                   cmd.Execute();
        //                   nodeIdSet.Add(des);
        //               }

        //               cmd.CommandText = "g.V('" + src + "').addE('appear').to(g.V('" + des + "')).next()";
        //               cmd.Execute();
        //           }
        //           else
        //           {
        //               c++;
        //           }
        //       }
        //       connection.getMetricsOfGraphPartition();
        //   }

        public static void insertCitHashPartitionByBulkInsert(String colName)
        {
            //GraphViewConnection connection =
            //new GraphViewConnection("https://graphview.documents.azure.com:443/",
            //   "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
            //   "GroupMatch", "CitHashPartition1000item", GraphType.GraphAPIOnly, false,
            //   1, null);

            GraphViewConnection connection = GraphViewConnection.ResetGraphAPICollection("https://graphview.documents.azure.com:443/",
       "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
       "GroupMatch", colName,
       false, 1, "name");

            //GraphViewConnection connection =
            //new GraphViewConnection("https://graphview.documents.azure.com:443/",
            //   "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
            //   "GroupMatch", "MarvelTest", GraphType.GraphAPIOnly, false,
            //   1, null);
            connection.EdgeSpillThreshold = 1;
            GraphViewConnection.partitionNum = 100;
            GraphViewConnection.partitionLoad = new int[100];
            GraphViewConnection.useHashPartitionWhenCreateDoc = true;
            GraphViewConnection.useBulkInsert = true;
            GraphViewCommand cmd = new GraphViewCommand(connection);
            HashSet<String> nodeIdSet = new HashSet<String>();

            int c = 1;
            var linesE = File.ReadLines("E:\\dataset\\thsinghua_dataset\\p2p-Gnutella08\\p2p-Gnutella08.txt");
            BulkInsertUtils blk = new BulkInsertUtils(GraphViewConnection.partitionNum);
            blk.threadNum = 100;
            blk.initBulkInsertUtilsForParseData(GraphViewConnection.partitionNum, linesE.Count(), connection);
            int i = 0;
            foreach (var lineE in linesE)
            {
                //if (i > 1000)
                //{
                //    break;
                //}
                //else
                //{
                //    i++;
                //}
                //if (c > 4)
                //{
                    blk.stringBufferList.Add(lineE);
                    Console.WriteLine(c);
                    c++;
                //}
                //else
                //{
                //    c++;
                //}
            }
            blk.startParseThread();
            blk.parseDataCountDownLatch.Await();
            blk.initAndStartInsertNodeStringCMD();
            blk.insertNodeCountDownLatch.Await();
            blk.initAndStartInsertEdgeStringCMD();
            GraphViewConnection.bulkInsertUtil.startParseThread();
            connection.getMetricsOfGraphPartition();
        }

        public static void insertCitGreedyPartitionByBulkInsert(String colName)
        {
            //GraphViewConnection connection =
            //new GraphViewConnection("https://graphview.documents.azure.com:443/",
            //   "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
            //   "GroupMatch", "CitGreedyPartition1000item", GraphType.GraphAPIOnly, false,
            //   1, null);

            GraphViewConnection connection = GraphViewConnection.ResetGraphAPICollection("https://graphview.documents.azure.com:443/",
            "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
            "GroupMatch", colName,
            false, 1, "name");

            //GraphViewConnection connection =
            //new GraphViewConnection("https://graphview.documents.azure.com:443/",
            //   "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
            //   "GroupMatch", "MarvelTest", GraphType.GraphAPIOnly, false,
            //   1, null);
            connection.EdgeSpillThreshold = 1;
            GraphViewConnection.partitionNum = 100;
            GraphViewConnection.partitionLoad = new int[100];
            GraphViewConnection.useHashPartitionWhenCreateDoc = true;
            GraphViewConnection.useGreedyPartitionWhenCreateDoc = false;
            GraphViewConnection.useBulkInsert = true;
            GraphViewCommand cmd = new GraphViewCommand(connection);
            HashSet<String> nodeIdSet = new HashSet<String>();

            int c = 1;
            var linesE = File.ReadLines("E:\\dataset\\thsinghua_dataset\\cit_network\\cit-HepTh.txt\\Cit-HepTh.txt");
            BulkInsertUtils blk = new BulkInsertUtils(GraphViewConnection.partitionNum);
            blk.threadNum = 100;
            blk.initBulkInsertUtilsForParseData(GraphViewConnection.partitionNum, linesE.Count(), connection);
            int i = 0;
            foreach (var lineE in linesE)
            {
                if (i > 1000)
                {
                    break;
                }
                else
                {
                    i++;
                }
                if (c > 4)
                {
                    blk.stringBufferList.Add(lineE);
                    Console.WriteLine(c);
                    c++;
                }
                else
                {
                    c++;
                }
            }
            blk.startParseThread();
            blk.parseDataCountDownLatch.Await();
            blk.initAndStartInsertNodeStringCMD();
            blk.insertNodeCountDownLatch.Await();
            blk.initAndStartInsertEdgeStringCMD();
            GraphViewConnection.bulkInsertUtil.startParseThread();
            connection.getMetricsOfGraphPartition();
        }

        //public static void insertCitDataBulkInsert()
        //{
        //    //          GraphViewConnection connection = GraphViewConnection.ResetGraphAPICollection("https://graphview.documents.azure.com:443/",
        //    //"MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
        //    //"GroupMatch", "CitAllDataHashPartition",
        //    //false, 1, "id");
        //    GraphViewConnection connection =
        //    new GraphViewConnection("https://graphview.documents.azure.com:443/",
        //       "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
        //       "GroupMatch", "CitAllDataHashPartition", GraphType.GraphAPIOnly, false,
        //       1, null);

        //    //GraphViewConnection connection =
        //    //new GraphViewConnection("https://graphview.documents.azure.com:443/",
        //    //   "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
        //    //   "GroupMatch", "MarvelTest", GraphType.GraphAPIOnly, false,
        //    //   1, null);
        //    connection.EdgeSpillThreshold = 1;
        //    GraphViewConnection.useHashPartitionWhenCreateDoc = true;
        //    GraphViewConnection.useBulkInsert = true;
        //    GraphViewCommand cmd = new GraphViewCommand(connection);
        //    HashSet<String> nodeIdSet = new HashSet<String>();

        //    int c = 1;
        //    var linesE = File.ReadLines("D:\\dataset\\thsinghua_dataset\\cit_network\\cit-HepTh.txt\\Cit-HepTh.txt");
        //    BulkInsertUtils blk = new BulkInsertUtils();
        //    blk.threadNum = 10;
        //    blk.initBulkInsertUtilsForParseData(GraphViewConnection.partitionNum, linesE.Count(), connection);
        //    int i = 0;
        //    foreach (var lineE in linesE)
        //    {
        //        //if(i > 100)
        //        //{
        //        //    break;
        //        //} else
        //        //{
        //        //    i++;
        //        //}
        //        if (c > 4)
        //        {
        //            blk.stringBufferList.Add(lineE);
        //            Console.WriteLine(c);
        //            c++;
        //        }
        //        else
        //        {
        //            c++;
        //        }
        //    }
        //    blk.startParseThread();
        //    blk.parseDataCountDownLatch.Await();
        //    blk.initAndStartInsertNodeStringCMD();
        //    blk.insertNodeCountDownLatch.Await();
        //    blk.initAndStartInsertEdgeStringCMD();
        //    GraphViewConnection.bulkInsertUtil.startParseThread();
        //    connection.getMetricsOfGraphPartition();
        //}

        public static void getStatistic()
        {
            Console.WriteLine("start statistic 1");
            GraphViewConnection connection1 =
        new GraphViewConnection("https://graphview.documents.azure.com:443/",
           "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
           "GroupMatch", "CitHashPartition1000item", GraphType.GraphAPIOnly, false,
           1, null);
            //connection1.getMetricsOfGraphPartition();
            connection1.getMetricsOfGraphPartitionInCache(100);

            Console.WriteLine("end statistic 1");
            Console.WriteLine("start statistic 2");
            GraphViewConnection connection2 =
        new GraphViewConnection("https://graphview.documents.azure.com:443/",
           "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
           "GroupMatch", "CitGreedyPartition1000item", GraphType.GraphAPIOnly, false,
           1, null);
            //connection2.getMetricsOfGraphPartition();
            connection2.getMetricsOfGraphPartitionInCache(100);
            Console.WriteLine("end statistic 2");

            Console.WriteLine("start statistic 3");

            GraphViewConnection connection3 =
       new GraphViewConnection("https://graphview.documents.azure.com:443/",
          "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
          "GroupMatch", "CitGreedyRePartition1000item", GraphType.GraphAPIOnly, false,
          1, null);
            //connection1.getMetricsOfGraphPartition();
            connection3.getMetricsOfGraphPartitionInCache(100);

            Console.WriteLine("end statistic 3");
            Console.WriteLine("start statistic 4");

         //   GraphViewConnection connection4 =
        //new GraphViewConnection("https://graphview.documents.azure.com:443/",
        //   "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
        //   "GroupMatch", "CitFakeDiffPartition", GraphType.GraphAPIOnly, false,
        //   1, null);
        //    //connection1.getMetricsOfGraphPartition();
        //    connection4.getMetricsOfGraphPartitionInCache(3);

        //    Console.WriteLine("end statistic 3");
        //    Console.WriteLine("start statistic 4");
        //    GraphViewConnection connection5 =
        //new GraphViewConnection("https://graphview.documents.azure.com:443/",
        //   "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
        //   "GroupMatch", "CitFakeSamePartition", GraphType.GraphAPIOnly, false,
        //   1, null);
        //    //connection2.getMetricsOfGraphPartition();
        //    connection5.getMetricsOfGraphPartitionInCache(1);
        //    Console.WriteLine("end statistic 2");
        }

        public static void insertInSamePartition()
        {
            var edgeList = new List<String>();
            // partitionData in 3 partitions
            // partitionData in 3 partitions
            for (int i = 0; i < 5; i++)
            {
                // p1
                for (int j = 0; j < 5; j++)
                {
                    edgeList.Add(0 + "-" + i + "\t" + 1 + "-" + j);
                    // p2
                    for (int k = 0; k < 5; k++)
                    {
                        // p3
                        edgeList.Add(0 + "-" + i + "\t" + 1 + "-" + k);
                        edgeList.Add(1 + "-" + j + "\t" + 2 + "-" + k);
                        edgeList.Add(2 + "-" + k + "\t" + 0 + "-" + i);
                    }
                }
            }

            GraphViewConnection connection = GraphViewConnection.ResetGraphAPICollection("https://graphview.documents.azure.com:443/",
  "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
  "GroupMatch", "CitFakeSamePartition", false, 1, "name");
            connection.EdgeSpillThreshold = 1;
            GraphViewConnection.partitionNum = 3;
            GraphViewConnection.useHashPartitionWhenCreateDoc = false;
            GraphViewConnection.useFakePartitionWhenCreateDoc = true;
            GraphViewConnection.useBulkInsert = true;
            GraphViewConnection.useFakePartitionWhenCreateDocIn1Partition = true;
            GraphViewCommand cmd = new GraphViewCommand(connection);
            HashSet<String> nodeIdSet = new HashSet<String>();
          
            BulkInsertUtils blk = new BulkInsertUtils(GraphViewConnection.partitionNum);
            blk.threadNum = 3;
            blk.initBulkInsertUtilsForParseData(GraphViewConnection.partitionNum, edgeList.Count, connection);
            //int j = 0;
            var linesE = edgeList;
            foreach (var lineE in linesE)
            {
                blk.stringBufferList.Add(lineE);
            }
            blk.startParseThread();
            blk.parseDataCountDownLatch.Await();
            blk.initAndStartInsertNodeStringCMD();
            blk.insertNodeCountDownLatch.Await();
            blk.initAndStartInsertEdgeStringCMD();
            GraphViewConnection.bulkInsertUtil.startParseThread();
            //connection.getMetricsOfGraphPartition();
        }

        public void partitionQueryTestCommonForQuery(String collectionName)
        {
            // (1) FindNeighbours (FN): finds the neighbours of all nodes.
            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
               "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
               "GroupMatch", collectionName, GraphType.GraphAPIOnly, false, 1, "name");
            GraphViewCommand graph = new GraphViewCommand(connection);
            //graph.OutputFormat = OutputFormat.GraphSON;
            DateTime start1 = DateTime.Now;
            var results = graph.g().V("9304045").Out().Out().Next();

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            DateTime end1 = DateTime.Now;
            Console.WriteLine("(1)" + (end1.Millisecond - start1.Millisecond) + "ms");

            //// (2) FindAdjacentNodes (FA): finds the 3-hop adjacent
            DateTime start2 = DateTime.Now;
            results = graph.g().V().Out().Out().Next();

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            DateTime end2 = DateTime.Now;
            Console.WriteLine("(2)" + (end2.Millisecond - start2.Millisecond) + "ms");
            // (3) Shortest Path: FindShortestPath (FS): finds the shortest path between the first node and 100 randomly picked nodes.

            //results = graph.g().V().Next(); // change the the result format or just hack a test suite
            //HashSet<int> index = new HashSet<int> { 1, 15 };
            //List<String> nodes = new List<string>();
            //int i = 0;
            //foreach (var result in results)
            //{
            //    i++;
            //    if (index.Contains(i))
            //    {
            //        nodes.Add(result);
            //    }
            //}

            //DateTime start3 = DateTime.Now;
            //String src = nodes[0];
            //nodes.RemoveAt(0);
            //foreach (var node in nodes)
            //{
            //    String des = node;
            //    ShortestPathTest.GetShortestPath(src, des, graph);
            //}
            //DateTime end3 = DateTime.Now;
            //Console.WriteLine("(3)" + (end3.Millisecond - start3.Millisecond) + "ms");
        }

        public static void insertDiffKeyPartitionBulkInsert(String collectionName, int partitionNum)
        {
            //GraphViewConnection connection =
            //new GraphViewConnection("https://graphview.documents.azure.com:443/",
            //   "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
            //   "GroupMatch", "CitHashPartition1000item", GraphType.GraphAPIOnly, false,
            //   1, null);

            GraphViewConnection connection = GraphViewConnection.ResetGraphAPICollection("https://graphview.documents.azure.com:443/",
       "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
       "GroupMatch", collectionName,
       false, 1, "id");
            connection.initPartitionConfig(partitionNum);
            //GraphViewConnection connection =
            //new GraphViewConnection("https://graphview.documents.azure.com:443/",
            //   "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
            //   "GroupMatch", "MarvelTest", GraphType.GraphAPIOnly, false,
            //   1, null);
            connection.EdgeSpillThreshold = 1;
            GraphViewConnection.useHashPartitionWhenCreateDoc = true;
            GraphViewConnection.useBulkInsert = true;
            //GraphViewConnection.partitionNum = partitionNum;
            GraphViewCommand cmd = new GraphViewCommand(connection);
            HashSet<String> nodeIdSet = new HashSet<String>();

            int c = 1;
            var linesE = File.ReadLines("D:\\dataset\\thsinghua_dataset\\cit_network\\cit-HepTh.txt\\Cit-HepTh.txt");
            BulkInsertUtils blk = new BulkInsertUtils(GraphViewConnection.partitionNum);
            //blk.threadNum = 10;
            blk.initBulkInsertUtilsForParseData(GraphViewConnection.partitionNum, linesE.Count(), connection);
            int i = 0;
            foreach (var lineE in linesE)
            {
                if (i > 1000)
                {
                    break;
                }
                else
                {
                    i++;
                }
                if (c > 4)
                {
                    blk.stringBufferList.Add(lineE);
                    Console.WriteLine(c);
                    c++;
                }
                else
                {
                    c++;
                }
            }
            blk.startParseThread();
            blk.parseDataCountDownLatch.Await();
            blk.initAndStartInsertNodeStringCMD();
            blk.insertNodeCountDownLatch.Await();
            blk.initAndStartInsertEdgeStringCMD();
            GraphViewConnection.bulkInsertUtil.startParseThread();
            ////connection.getMetricsOfGraphPartition();
        }

        public static void insertControlPartitionkeyBulkInsert_ExtremeCaseInOnePartition(String collectionName, int partitionNum, int startPartitionOffset)
        {

            var edgeList = new List<String>();
            // partitionData in 3 partitions
            // partitionData in 3 partitions
            int partitionNodesPerPartition = 6;
            var rnd = new Random();
            HashSet<String> vertex = new HashSet<string>();
            for (int t = 0; t < 1; t++)
            {
                // p1
                for (int j = startPartitionOffset; j < partitionNum + startPartitionOffset;)
                {
                    //for (int k = 0; k < partitionNum + startPartitionOffset; k++)
                    //{
                        var src = t + "-" + j;
                        var des = t + "-" + (j + 1);
                        var r = rnd.Next();
                        var d = r % 10;
                        if (src == des)
                        {
                            continue;
                        }
                        if (vertex.Contains(src) && vertex.Contains(des) && (d > 2))
                        {
                            continue;
                        }
                        else
                        {
                            edgeList.Add(src + "\t" + des);
                            vertex.Add(src);
                            vertex.Add(des);
                        }
                    //}
                    j += 2;
                }
            }

            //     GraphViewConnection connection = GraphViewConnection.ResetGraphAPICollection("https://graphview.documents.azure.com:443/",
            //"MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
            //"GroupMatch", collectionName,
            //false, 1, "id");
            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
                    "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
                    "GroupMatch", collectionName, GraphType.GraphAPIOnly, false, 1, "name");
            connection.initPartitionConfig(partitionNum);
            connection.EdgeSpillThreshold = 1;
            GraphViewConnection.useHashPartitionWhenCreateDoc = false;
            GraphViewConnection.useFakePartitionWhenCreateDoc = true;
            GraphViewConnection.useBulkInsert = true;
            GraphViewCommand cmd = new GraphViewCommand(connection);
            HashSet<String> nodeIdSet = new HashSet<String>();

            int c = 1;
            //var linesE = File.ReadLines("D:\\dataset\\thsinghua_dataset\\cit_network\\cit-HepTh.txt\\Cit-HepTh.txt");
            var linesE = edgeList.ToList();
            BulkInsertUtils blk = new BulkInsertUtils(GraphViewConnection.partitionNum);
            blk.initBulkInsertUtilsForParseData(GraphViewConnection.partitionNum, linesE.Count(), connection);
            int i = 0;

            foreach (var lineE in linesE)
            {
                blk.stringBufferList.Add(lineE);
                Console.WriteLine(c);
            }
            blk.startParseThread();
            blk.parseDataCountDownLatch.Await();
            blk.initAndStartInsertNodeStringCMD();
            blk.insertNodeCountDownLatch.Await();
            blk.initAndStartInsertEdgeStringCMD();
            GraphViewConnection.bulkInsertUtil.startParseThread();
            ////connection.getMetricsOfGraphPartition();
        }

        public static void insertControlPartitionkeyBulkInsert_ExtremeCase(String collectionName, int partitionNum, int startPartitionOffset)
        {

            var edgeList = new List<String>();
            // partitionData in 3 partitions
            // partitionData in 3 partitions
            int partitionNodesPerPartition = 6;
            var rnd = new Random();
            HashSet<String> vertex = new HashSet<string>();
            for (int t = startPartitionOffset; t < (partitionNum + startPartitionOffset); t++)
            {
                // p1
                for (int j = 0; j < partitionNodesPerPartition / 3; j++)
                {
                    for (int k = 0; k < partitionNodesPerPartition / 3; k++)
                    {
                        var src = t + "-" + j;
                        var des = t + "-" + k;
                        var r = rnd.Next();
                        var d = r % 10;
                        if (src == des)
                        {
                            continue;
                        }
                        if (vertex.Contains(src) && vertex.Contains(des) && (d > 2))
                        {
                            continue;
                        }
                        else
                        {
                            edgeList.Add(t + "-" + j + "\t" + t + "-" + k);
                            vertex.Add(src);
                            vertex.Add(des);
                        }
                    }
                }
            }

            //     GraphViewConnection connection = GraphViewConnection.ResetGraphAPICollection("https://graphview.documents.azure.com:443/",
            //"MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
            //"GroupMatch", collectionName,
            //false, 1, "id");
            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
                    "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
                    "GroupMatch", collectionName, GraphType.GraphAPIOnly, false, 1, "name");
            connection.initPartitionConfig(partitionNum);
            connection.EdgeSpillThreshold = 1;
            GraphViewConnection.useHashPartitionWhenCreateDoc = false;
            GraphViewConnection.useFakePartitionWhenCreateDoc = true;
            GraphViewConnection.useBulkInsert = true;
            GraphViewCommand cmd = new GraphViewCommand(connection);
            HashSet<String> nodeIdSet = new HashSet<String>();

            int c = 1;
            //var linesE = File.ReadLines("D:\\dataset\\thsinghua_dataset\\cit_network\\cit-HepTh.txt\\Cit-HepTh.txt");
            var linesE = edgeList.ToList();
            BulkInsertUtils blk = new BulkInsertUtils(GraphViewConnection.partitionNum);
            blk.initBulkInsertUtilsForParseData(GraphViewConnection.partitionNum, linesE.Count(), connection);
            int i = 0;

            foreach (var lineE in linesE)
            {
                blk.stringBufferList.Add(lineE);
                Console.WriteLine(c);
            }
            blk.startParseThread();
            blk.parseDataCountDownLatch.Await();
            blk.initAndStartInsertNodeStringCMD();
            blk.insertNodeCountDownLatch.Await();
            blk.initAndStartInsertEdgeStringCMD();
            GraphViewConnection.bulkInsertUtil.startParseThread();
            ////connection.getMetricsOfGraphPartition();
        }

        public static void insertControlPartitionkeyBulkInsert(String collectionName, int partitionNum)
        {

            var edgeList = new List<String>();
            // partitionData in 3 partitions
            // partitionData in 3 partitions
            int partitionNodesPerPartition = 100;
            var rnd = new Random();
            HashSet<String> vertex = new HashSet<string>();
            for (int t = 0; t < partitionNum; t++)
            {
                // p1
                for (int j = 0; j < partitionNodesPerPartition / 3; j++)
                {
                    for(int k = 0; k < partitionNodesPerPartition / 3; k ++)
                    {
                        var src = t + "-" + j;
                        var des = t + "-" + k;
                        var r = rnd.Next();
                        var d = r % 10;
                        if(src == des)
                        {
                            continue;
                        }
                        if (vertex.Contains(src) && vertex.Contains(des) && (d > 2))
                        {
                            continue;
                        }
                        else
                        {
                            edgeList.Add(t + "-" + j + "\t" + t + "-" + k);
                            vertex.Add(src);
                            vertex.Add(des);
                        }
                    }
                }
            }

            //     GraphViewConnection connection = GraphViewConnection.ResetGraphAPICollection("https://graphview.documents.azure.com:443/",
            //"MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
            //"GroupMatch", collectionName,
            //false, 1, "id");
            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
                    "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
                    "GroupMatch", collectionName, GraphType.GraphAPIOnly, false, 1, "name");
            connection.initPartitionConfig(partitionNum);
            connection.EdgeSpillThreshold = 1;
            GraphViewConnection.useHashPartitionWhenCreateDoc = false;
            GraphViewConnection.useFakePartitionWhenCreateDoc = true;
            GraphViewConnection.useBulkInsert = true;
            GraphViewCommand cmd = new GraphViewCommand(connection);
            HashSet<String> nodeIdSet = new HashSet<String>();

            int c = 1;
            //var linesE = File.ReadLines("D:\\dataset\\thsinghua_dataset\\cit_network\\cit-HepTh.txt\\Cit-HepTh.txt");
            var linesE = edgeList.ToList();
            BulkInsertUtils blk = new BulkInsertUtils(GraphViewConnection.partitionNum);
            blk.initBulkInsertUtilsForParseData(GraphViewConnection.partitionNum, linesE.Count(), connection);
            int i = 0;

            foreach (var lineE in linesE)
            {
               blk.stringBufferList.Add(lineE);
               Console.WriteLine(c);
            }
            blk.startParseThread();
            blk.parseDataCountDownLatch.Await();
            blk.initAndStartInsertNodeStringCMD();
            blk.insertNodeCountDownLatch.Await();
            blk.initAndStartInsertEdgeStringCMD();
            GraphViewConnection.bulkInsertUtil.startParseThread();
            ////connection.getMetricsOfGraphPartition();
        }

        public static void partitionQueryDiffPartitionTest(String collectionName)
        {
            // (1) FindNeighbours (FN): finds the neighbours of all nodes.
            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
               "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
               "GroupMatch", collectionName, GraphType.GraphAPIOnly, false, 1, "name");
            GraphViewCommand graph = new GraphViewCommand(connection);
            //graph.OutputFormat = OutputFormat.GraphSON;

            var start0 = Stopwatch.StartNew();
            var results0 = graph.g().V(new List<Object> {"100-57", "100-69", "100-66"}).Next();
            var rc0 = results0.Count();

            foreach (var result in results0)
            {
                Console.WriteLine(result);
            }
            start0.Stop();
            Console.WriteLine("partition" + 2 + " Result Count" + rc0 + "(1)" + (start0.ElapsedMilliseconds) + "ms");



            List<Object> ids1 = new List<object>();
            for (int p = 0; p < 1; p++)
            {
                for(int v = 0; v < 100; v ++)
                {
                    ids1.Add(p + "-" + v);
                }
            }
            var start1 = Stopwatch.StartNew();
            var results = graph.g().V(ids1).Next();
            var rc1 = results.Count;

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            start1.Stop();
            Console.WriteLine("partition" + ids1.Count() + " Result Count" + rc1 + "(1)" + (start1.ElapsedMilliseconds) + "ms");

            List<Object> ids2 = new List<object>();
            for (int p = 0; p < 10; p++)
            {
                for (int v = 0; v < 10; v++)
                {
                    ids2.Add(p + "-" + v);
                }
            }
            var start2 = Stopwatch.StartNew();
            results = graph.g().V(ids2).Next();
            var rc2 = results.Count;

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            start2.Stop();
            Console.WriteLine("partition" + ids2.Count() + " Result Count" + rc2 + "(2)" + (start2.ElapsedMilliseconds) + "ms");


            List<Object> ids3 = new List<object>();
            for (int p = 0; p < 100; p++)
            {
                for (int v = 0; v < 1; v++)
                {
                    ids3.Add(p + "-" + v);
                }
            }
            var start3 = Stopwatch.StartNew();
            results = graph.g().V(ids3).Next();
            var rc3 = results.Count;
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
            start3.Stop();
            Console.WriteLine("partition:" + ids3.Count() + " Result Count" + rc3 + "(3)" + (start3.ElapsedMilliseconds) + "ms");
        }

        public static void insertClusterNodeFakeBulkInsert(String collectionName, int partitionNum, bool crossConnection)
        {
            // 30 * 30 fake partition cluster and random
            var edgeList = new List<String>();
            int partitionNodesPerPartition = 100;
            var rnd = new Random();
            HashSet<String> vertex = new HashSet<String>();

            // (1) cross partition
            if (crossConnection)
            {
                for (int k = 0; k < 30; k++)
                {
                    for (int v = 0; v < 30; v++)
                    {
                        var src = k + "-" + v;
                        var des = (k + 1) % 30 + "-" + v;

                        if (vertex.Contains(src) && vertex.Contains(des))
                        {
                            continue;
                        }
                        else
                        {
                            edgeList.Add(src + "\t" + des);
                            vertex.Add(src);
                            vertex.Add(des);
                        }
                    }
                }
            } else
            {
                for (int k = 0; k < 30; k++)
                {
                    for (int v = 0; v < 30; v++)
                    {
                        var src = k + "-" + v;
                        var des = (k) + "-" + (v + 1) % 30;
                        if (vertex.Contains(src) && vertex.Contains(des))
                        {
                            continue;
                        }
                        else
                        {
                            edgeList.Add(src + "\t" + des);
                            vertex.Add(src);
                            vertex.Add(des);
                        }
                    }
                }
            }

            //     GraphViewConnection connection = GraphViewConnection.ResetGraphAPICollection("https://graphview.documents.azure.com:443/",
            //"MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
            //"GroupMatch", collectionName,
            //false, 1, "id");
            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
                    "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
                    "GroupMatch", collectionName, GraphType.GraphAPIOnly, false, 1, "name");
            connection.initPartitionConfig(partitionNum);
            connection.EdgeSpillThreshold = 1;
            GraphViewConnection.useHashPartitionWhenCreateDoc = false;
            GraphViewConnection.useFakePartitionWhenCreateDoc = true;
            GraphViewConnection.useBulkInsert = true;
            GraphViewCommand cmd = new GraphViewCommand(connection);
            HashSet<String> nodeIdSet = new HashSet<String>();

            int c = 1;
            //var linesE = File.ReadLines("D:\\dataset\\thsinghua_dataset\\cit_network\\cit-HepTh.txt\\Cit-HepTh.txt");
            var linesE = edgeList.ToList();
            BulkInsertUtils blk = new BulkInsertUtils(GraphViewConnection.partitionNum);
            blk.initBulkInsertUtilsForParseData(GraphViewConnection.partitionNum, linesE.Count(), connection);
            int i = 0;

            foreach (var lineE in linesE)
            {
                blk.stringBufferList.Add(lineE);
                Console.WriteLine(c);
            }
            blk.startParseThread();
            blk.parseDataCountDownLatch.Await();
            blk.initAndStartInsertNodeStringCMD();
            blk.insertNodeCountDownLatch.Await();
            blk.initAndStartInsertEdgeStringCMD();
            //GraphViewConnection.bulkInsertUtil.startParseThread();
        }

        public static void queryCrossOrFakePartitionCross (String collectionName)
        {
            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
              "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
              "GroupMatch", collectionName, GraphType.GraphAPIOnly, false,
              1, null);
            GraphViewCommand graph = new GraphViewCommand(connection);
            //graph.OutputFormat = OutputFormat.GraphSON;
            List<Object> vertexIds0 = new List<object>();
            for (int p = 0; p < 1; p++)
            {
                for (int i = 0; i < 30; i++)
                {
                    vertexIds0.Add(p + "-" + i);
                }
            }
            var start10 = Stopwatch.StartNew();
            var results0 = graph.g().V(vertexIds0).Next();

            foreach (var result in results0)
            {
                Console.WriteLine(result);
            }
            start10.Stop();
            Console.WriteLine("warm query " + 1 + "  " + collectionName + "(0)" + (start10.ElapsedMilliseconds) + "ms");

            // (1) query 1 partition
            List<Object> vertexIds = new List<object>();
            for (int p = 0; p < 30; p++)
            {
                for (int i = 0; i < 1; i++)
                {
                    vertexIds.Add(p + "-" + i);
                }
            }
            // (1) Out Out
            var start1 = Stopwatch.StartNew();
            var results = graph.g().V(vertexIds).Out("appear").Out("appear").Next();

            foreach (var result in results)
            {
                //Console.WriteLine(result);
            }
            start1.Stop();
            Console.WriteLine("partition count" + 1 + "  " + collectionName + "(0)" + (start1.ElapsedMilliseconds) + "ms");

            //// (2) SSSP
            //var start2 = Stopwatch.StartNew();
            //results = graph.g().V(vertexIds).Out("appear").Out("appear").Next();

            //foreach (var result in results)
            //{
            //    Console.WriteLine(result);
            //}
            //start2.Stop();
            //Console.WriteLine("partition count" + 1 + "  " + collectionName + "(0)" + (start2.ElapsedMilliseconds) + "ms");
        }

        public static void queryCrossOrFakePartitionNotCross(String collectionName)
        {
            GraphViewConnection connection = new GraphViewConnection("https://graphview.documents.azure.com:443/",
              "MqQnw4xFu7zEiPSD+4lLKRBQEaQHZcKsjlHxXn2b96pE/XlJ8oePGhjnOofj1eLpUdsfYgEhzhejk2rjH/+EKA==",
              "GroupMatch", collectionName, GraphType.GraphAPIOnly, false,
              1, null);
            GraphViewCommand graph = new GraphViewCommand(connection);
            //graph.OutputFormat = OutputFormat.GraphSON;
            List<Object> vertexIds0 = new List<object>();
            for (int p = 1; p < 2; p++)
            {
                for (int i = 0; i < 30; i++)
                {
                    vertexIds0.Add(p + "-" + i);
                }
            }
            var start10 = Stopwatch.StartNew();
            var results0 = graph.g().V(vertexIds0).Next();

            foreach (var result in results0)
            {
                Console.WriteLine(result);
            }
            start10.Stop();
            Console.WriteLine("warm query " + 1 + "  " + collectionName + "(0)" + (start10.ElapsedMilliseconds) + "ms");

            // (1) query 1 partition
            List<Object> vertexIds = new List<object>();
            for (int p = 0; p < 1; p++)
            {
                for (int i = 0; i < 30; i++)
                {
                    vertexIds.Add(p + "-" + i);
                }
            }
            var start1 = Stopwatch.StartNew();
            var results = graph.g().V(vertexIds).Out("appear").Out("appear").Next();

            foreach (var result in results)
            {
                //Console.WriteLine(result);
            }
            start1.Stop();
            Console.WriteLine("partition count" + 30 + "  " + collectionName + "(0)" + (start1.ElapsedMilliseconds) + "ms");
        }
    }
}
