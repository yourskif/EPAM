# Dependency Injection. Uri serialization.

A advanced level task for practicing the dependency injection (DI) software design pattern in .NET.

In this task you learn how to
- use the "[Stairway Pattern](https://makingloops.com/the-stairway-pattern/)" to decouple your projects
- create a .NET console app that uses dependency injection
- write several interfaces and corresponding implementations
- use service lifetime and scoping for DI
- use the dependency injection along with configuration, logging. 

Additionally, you will be able to repeat various .NET technologies for working with xml and json.

Estimated time to complete the task: 6h.

## Task Description

The type system that describe the logic of the export of the string representation of the data to the other format (see [Convertion](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/Conversion/IConverter.cs#L7), [Validation](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/Validation/IValidator.cs#L7), [Serialization](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/Serialization/IDataSerializer.cs#L17), [DataReceiving](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/DataReceiving/IDataReceiver.cs#L8), [ExportDataService](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/Conversion/IConverter.cs#L7)) are present in solution.
<details><summary>See scheme.</summary>

  ![](/Images/Architecture1.png)

</details>

Use this types to develop a type system 
  - to reveive as `IEnumerable<string>` data represented as strings that store the information about Uri's in the form `<scheme>://<host>/<path>?<query>`, where   
    - `path` may consist of segments of the form `segment1/segment2/.../segmentN`,
    - `query` consist pairs of the form `key1=value1&...&keyK=valueK`.
  - to convert string object to [Uri](https://docs.microsoft.com/en-us/dotnet/api/system.uri?view=net-6.0) object.
  - to export `IEnumerable<Uri>` to XML and JSON formats.
  
#### Task details.
- In implementation the string receiver functionality consider getting data from both [text](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/TextFileReceiver/TextStreamReceiver.cs#L11) file and [memory](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/InMemoryReceiver/InMemoryDataReceiver.cs#L9).
  <details><summary>See a scheme.</summary>

    ![](/Images/Architecture3.png)

  </details>
  <details>
  <summary>See an example of string data.</summary>

  ```
  https://habrahabr.ru/company/it-grad/blog/341486/
  http://www.example.com/customers/12345
  http://www.example.com/customers/12345/orders/98765
  https://qaevolution.ru/znakomstvo-s-testirovaniem-api/
  http://
  https://www.contoso.com/Home/Index.htm?q1=v1&q2=v2
  http://aaa.com/temp?key=Foo&value=Bar&id=42
  https://www.w3schools.com/html/default.asp
  http://www.ninject.org/learn.html
  https:.php
  https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/linq/linq-to-xml-overview
  docs.microsoft.com
  microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/l
  https://docs.microsoft.com/ru-ru/dotnet/api/system.linq.queryable.where?view=netframework-4.8
  https://docs.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlserializer?view=net-6.0
  https://metanit.com/python/django/1.1.php
  ```
  </details>

- In implementation the serialization logic consider following .NET technologies:
  - [XmlWrite](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/XmlWriter.Serialization/XmlWriterTechnology.cs#L12) class
  - [XmlSerializer](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/XmlSerializer.Serialization/XmlSerializerTechnology.cs#L12) class
  - [XML-DOM model](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/XmlDomWriter.Serialization/XmlDomTechnology.cs#L12)
  - [X-DOM model](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/XDomWriter.Serialization/XDomTechnology.cs#L12)
  - [JsonSerializer](https://gitlab.com/autocode-tasks/net-6/dependency-injection-uri-serialization/-/blob/main/JsonSerializer.Serialization/JsonSerializerTechnology.cs#L12) class.

  <details><summary>See a scheme.</summary>

    ![](/Images/Architecture2.png)

  </details>

  <details>
  <summary>See an example of XML format.</summary>

  ```
  <?xml version="1.0" encoding="utf-8"?>
  <uriAddresses>
      <uriAddress>
          <scheme name="https" />
          <host name="habrahabr.ru" />
          <path>
              <segment>company</segment>
              <segment>it-grad</segment>
              <segment>blog</segment>
              <segment>341486</segment>
          </path>
      </uriAddress>
      <uriAddress>
          <scheme name="http" />
          <host name="www.example.com" />
          <path>
              <segment>customers</segment>
              <segment>12345</segment>
          </path>
      </uriAddress>
      <uriAddress>
          <scheme name="http" />
          <host name="www.example.com" />
          <path>
              <segment>customers</segment>
              <segment>12345</segment>
              <segment>orders</segment>
              <segment>98765</segment>
          </path>
      </uriAddress>
      <uriAddress>
          <scheme name="https" />
          <host name="qaevolution.ru" />
          <path>
              <segment>znakomstvo-s-testirovaniem-api</segment>
          </path>
      </uriAddress>
      <uriAddress>
          <scheme name="https" />
          <host name="www.contoso.com" />
          <path>
              <segment>Home</segment>
              <segment>Index.htm</segment>
          </path>
          <query>
              <parameter key="q1" value="v1" />
              <parameter key="q2" value="v2" />
          </query>
      </uriAddress>
      <uriAddress>
          <scheme name="http" />
          <host name="aaa.com" />
          <path>
              <segment>temp</segment>
          </path>
          <query>
              <parameter key="key" value="Foo" />
              <parameter key="value" value="Bar" />
              <parameter key="id" value="42" />
          </query>
      </uriAddress>
      <uriAddress>
          <scheme name="https" />
          <host name="www.w3schools.com" />
          <path>
              <segment>html</segment>
              <segment>default.asp</segment>
          </path>
      </uriAddress>
      <uriAddress>
          <scheme name="http" />
          <host name="www.ninject.org" />
          <path>
              <segment>learn.html</segment>
          </path>
      </uriAddress>
      <uriAddress>
          <scheme name="https" />
          <host name="docs.microsoft.com" />
          <path>
              <segment>ru-ru</segment>
              <segment>dotnet</segment>
              <segment>csharp</segment>
              <segment>programming-guide</segment>
              <segment>concepts</segment>
              <segment>linq</segment>
              <segment>linq-to-xml-overview</segment>
          </path>
      </uriAddress>
      <uriAddress>
          <scheme name="https" />
          <host name="docs.microsoft.com" />
          <path>
              <segment>ru-ru</segment>
              <segment>dotnet</segment>
              <segment>api</segment>
              <segment>system.linq.queryable.where</segment>
          </path>
          <query>
              <parameter key="view" value="netframework-4.8" />
          </query>
      </uriAddress>
      <uriAddress>
          <scheme name="https" />
          <host name="docs.microsoft.com" />
          <path>
              <segment>en-us</segment>
              <segment>dotnet</segment>
              <segment>api</segment>
              <segment>system.xml.serialization.xmlserializer</segment>
          </path>
          <query>
              <parameter key="view" value="net-6.0" />
          </query>
      </uriAddress>
      <uriAddress>
          <scheme name="https" />
          <host name="metanit.com" />
          <path>
              <segment>python</segment>
              <segment>django</segment>
              <segment>1.1.php</segment>
          </path>
      </uriAddress>
  </uriAddresses>
  ```
  </details>

  <details>
  <summary>See an example of JSON format.</summary>
  
  ```
  [
    {
      "scheme": "https",
      "host": "habrahabr.ru",
      "path": [
        "company",
        "it-grad",
        "blog",
        "341486"
      ]
    },
    {
      "scheme": "http",
      "host": "www.example.com",
      "path": [
        "customers",
        "12345"
      ]
    },
    {
      "scheme": "http",
      "host": "www.example.com",
      "path": [
        "customers",
        "12345",
        "orders",
        "98765"
      ]
    },
    {
      "scheme": "https",
      "host": "qaevolution.ru",
      "path": [
        "znakomstvo-s-testirovaniem-api"
      ]
    },
    {
      "scheme": "https",
      "host": "www.contoso.com",
      "path": [
        "Home",
        "Index.htm"
      ],
      "query": [
        {
          "key": "q1",
          "value": "v1"
        },
        {
          "key": "q2",
          "value": "v2"
        }
      ]
    },
    {
      "scheme": "http",
      "host": "aaa.com",
      "path": [
        "temp"
      ],
      "query": [
        {
          "key": "key",
          "value": "Foo"
        },
        {
          "key": "value",
          "value": "Bar"
        },
        {
          "key": "id",
          "value": "42"
        }
      ]
    },
    {
      "scheme": "https",
      "host": "www.w3schools.com",
      "path": [
        "html",
        "default.asp"
      ]
    },
    {
      "scheme": "http",
      "host": "www.ninject.org",
      "path": [
        "learn.html"
      ]
    },
    {
      "scheme": "https",
      "host": "docs.microsoft.com",
      "path": [
        "ru-ru",
        "dotnet",
        "csharp",
        "programming-guide",
        "concepts",
        "linq",
        "linq-to-xml-overview"
      ]
    },
    {
      "scheme": "https",
      "host": "docs.microsoft.com",
      "path": [
        "ru-ru",
        "dotnet",
        "api",
        "system.linq.queryable.where"
      ],
      "query": [
        {
          "key": "view",
          "value": "netframework-4.8"
        }
      ]
    },
    {
      "scheme": "https",
      "host": "docs.microsoft.com",
      "path": [
        "en-us",
        "dotnet",
        "api",
        "system.xml.serialization.xmlserializer"
      ],
      "query": [
        {
          "key": "view",
          "value": "net-6.0"
        }
      ]
    },
    {
      "scheme": "https",
      "host": "metanit.com",
      "path": [
        "python",
        "django",
        "1.1.php"
      ]
    }
  ]
  
  ```
  </details>

- Strings that do not match the specified `<scheme>://<host>/<path>?<query>`-pattern are not converted to an object, respectively, for such strings, object serialization is not performed. Information about not valid string is logged. To log is used `NLog.Extensions.Logging` package.
- All unit tests should be pass.
- To demonstrate how it works with various receivers and serializers use console application.
- To resolve dependencies use the `Microsoft.Extensions.DependencyInjection` package.
- To configuration console application use `Microsoft.Extensions.Configuration` package.

## See also

 - [Dependency injection in .NET](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
 - [Dependency injection guidelines](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection-guidelines)
 - [Using NLog in a .NET 5 Console Application with Dependency Injection and send logs to AWS CloudWatch](https://dev.to/satish/using-nlog-in-a-net-5-console-application-with-dependency-injection-52mm)
