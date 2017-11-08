using System;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System.Xml;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
using CsvHelper;
using System.Runtime.Serialization;
using System.Net;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace pro2
{
    class Program
    {     
        static void Main(string[] args)
        {

            // var url ="http://localhost:5000/api/productinfo ";  
            // var json = new WebClient().DownloadString(url);
            // Console.WriteLine(json);
            // jsonToCSV(json);}
            //var t = _download_serialized_json_data <ProductInfo> (url);  
              

            //var url = "http://localhost:5000/api/productinfo ";
            

           // private static ProductInfo _download_serialized_json_data<T>(string url) where T : new() {
           // using (var w = new WebClient()) {
           // var json_data = string.Empty;
    // attempt to download JSON data as a string
           //try {
                // json_data = w.DownloadString(url);
               // }
            // catch (Exception) {}
    // if string with JSON data is not empty, deserialize it to class and return its instance 
                 // return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();

           var json =@"{
   ""sentences"": [
       {
           ""text"": {
               ""content"": ""My name is Sneha"",
               ""beginOffset"": 0
           }
       }
   ],
   ""tokens"": [
       {
           ""text"": {
               ""content"": ""My"",
               ""beginOffset"": 0
           },
           ""partOfSpeech"": {
               ""tag"": ""PRON"",
               ""aspect"": ""ASPECT_UNKNOWN"",
               ""case"": ""GENITIVE"",
               ""form"": ""FORM_UNKNOWN"",
               ""gender"": ""GENDER_UNKNOWN"",
               ""mood"": ""MOOD_UNKNOWN"",
               ""number"": ""SINGULAR"",
               ""person"": ""FIRST"",
               ""proper"": ""PROPER_UNKNOWN"",
               ""reciprocity"": ""RECIPROCITY_UNKNOWN"",
               ""tense"": ""TENSE_UNKNOWN"",
               ""voice"": ""VOICE_UNKNOWN""
           },
           ""dependencyEdge"": {
               ""headTokenIndex"": 1,
               ""label"": ""POSS""
           },
           ""lemma"": ""My""
       },
       {
           ""text"": {
               ""content"": ""name"",
               ""beginOffset"": 3
           },
           ""partOfSpeech"": {
               ""tag"": ""NOUN"",
               ""aspect"": ""ASPECT_UNKNOWN"",
               ""case"": ""CASE_UNKNOWN"",
               ""form"": ""FORM_UNKNOWN"",
               ""gender"": ""GENDER_UNKNOWN"",
               ""mood"": ""MOOD_UNKNOWN"",
               ""number"": ""SINGULAR"",
               ""person"": ""PERSON_UNKNOWN"",
               ""proper"": ""PROPER_UNKNOWN"",
               ""reciprocity"": ""RECIPROCITY_UNKNOWN"",
               ""tense"": ""TENSE_UNKNOWN"",
               ""voice"": ""VOICE_UNKNOWN""
           },
           ""dependencyEdge"": {
               ""headTokenIndex"": 2,
               ""label"": ""NSUBJ""
           },
           ""lemma"": ""name""
       },
       {
           ""text"": {
               ""content"": ""is"",
               ""beginOffset"": 8
           },
           ""partOfSpeech"": {
               ""tag"": ""VERB"",
               ""aspect"": ""ASPECT_UNKNOWN"",
               ""case"": ""CASE_UNKNOWN"",
               ""form"": ""FORM_UNKNOWN"",
               ""gender"": ""GENDER_UNKNOWN"",
               ""mood"": ""INDICATIVE"",
               ""number"": ""SINGULAR"",
               ""person"": ""THIRD"",
               ""proper"": ""PROPER_UNKNOWN"",
               ""reciprocity"": ""RECIPROCITY_UNKNOWN"",
               ""tense"": ""PRESENT"",
               ""voice"": ""VOICE_UNKNOWN""
           },
           ""dependencyEdge"": {
               ""headTokenIndex"": 2,
               ""label"": ""ROOT""
           },
           ""lemma"": ""be""
       },
       {
           ""text"": {
               ""content"": ""Sneha"",
               ""beginOffset"": 11
           },
           ""partOfSpeech"": {
               ""tag"": ""NOUN"",
               ""aspect"": ""ASPECT_UNKNOWN"",
               ""case"": ""CASE_UNKNOWN"",
               ""form"": ""FORM_UNKNOWN"",
               ""gender"": ""GENDER_UNKNOWN"",
               ""mood"": ""MOOD_UNKNOWN"",
               ""number"": ""SINGULAR"",
               ""person"": ""PERSON_UNKNOWN"",
               ""proper"": ""PROPER"",
               ""reciprocity"": ""RECIPROCITY_UNKNOWN"",
               ""tense"": ""TENSE_UNKNOWN"",
               ""voice"": ""VOICE_UNKNOWN""
           },
           ""dependencyEdge"": {
               ""headTokenIndex"": 2,
               ""label"": ""ATTR""
           },
           ""lemma"": ""Sneha""
       }
   ],
   ""language"": ""en""
}";
           jsonToCSV(json);
        }
      public static void jsonToCSV(string jsonContent)
           {

             //

    // //        //used NewtonSoft json nuget package
           XmlNode xml = JsonConvert.DeserializeXmlNode("{table:{table:" + jsonContent + "}}");
           Console.WriteLine(xml.OuterXml);
           
           XmlDocument xmldoc = new XmlDocument();
           xmldoc.LoadXml(xml.InnerXml);
           XmlReader xmlReader = new XmlNodeReader(xml);
           DataSet dataSet = new DataSet();
           dataSet.ReadXml(xmlReader);
           var dataTable = dataSet.Tables[4];
 
           //Datatable to CSV
           var lines = new List<string>();
           string[] columnNames = dataTable.Columns.Cast<DataColumn>().
                                             Select(column => column.ColumnName).
                                             ToArray();
           var header = string.Join(",", columnNames);
           lines.Add(header);
           var valueLines = dataTable.Select()
                              .Select(row => string.Join(",", row.ItemArray));
           lines.AddRange(valueLines);
           File.WriteAllLines(@"C:\Users\Administrator\Desktop\Insight\Insight-JSON to CSV/Export.csv", lines);
           //foreach(var record in lines){
               // Console.WriteLine(record);
            //}
       }
    }
}


