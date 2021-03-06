/**
 * Autogenerated by Thrift Compiler (0.12.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace TeleKinesisNet
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class CollectorPayload : TBase
  {
    private string _schema;
    private string _ipAddress;
    private long _timestamp;
    private string _encoding;
    private string _collector;
    private string _userAgent;
    private string _refererUri;
    private string _path;
    private string _querystring;
    private string _body;
    private List<string> _headers;
    private string _contentType;
    private string _hostname;
    private string _networkUserId;

    public string Schema
    {
      get
      {
        return _schema;
      }
      set
      {
        __isset.schema = true;
        this._schema = value;
      }
    }

    public string IpAddress
    {
      get
      {
        return _ipAddress;
      }
      set
      {
        __isset.ipAddress = true;
        this._ipAddress = value;
      }
    }

    public long Timestamp
    {
      get
      {
        return _timestamp;
      }
      set
      {
        __isset.timestamp = true;
        this._timestamp = value;
      }
    }

    public string Encoding
    {
      get
      {
        return _encoding;
      }
      set
      {
        __isset.encoding = true;
        this._encoding = value;
      }
    }

    public string Collector
    {
      get
      {
        return _collector;
      }
      set
      {
        __isset.collector = true;
        this._collector = value;
      }
    }

    public string UserAgent
    {
      get
      {
        return _userAgent;
      }
      set
      {
        __isset.userAgent = true;
        this._userAgent = value;
      }
    }

    public string RefererUri
    {
      get
      {
        return _refererUri;
      }
      set
      {
        __isset.refererUri = true;
        this._refererUri = value;
      }
    }

    public string Path
    {
      get
      {
        return _path;
      }
      set
      {
        __isset.path = true;
        this._path = value;
      }
    }

    public string Querystring
    {
      get
      {
        return _querystring;
      }
      set
      {
        __isset.querystring = true;
        this._querystring = value;
      }
    }

    public string Body
    {
      get
      {
        return _body;
      }
      set
      {
        __isset.body = true;
        this._body = value;
      }
    }

    public List<string> Headers
    {
      get
      {
        return _headers;
      }
      set
      {
        __isset.headers = true;
        this._headers = value;
      }
    }

    public string ContentType
    {
      get
      {
        return _contentType;
      }
      set
      {
        __isset.contentType = true;
        this._contentType = value;
      }
    }

    public string Hostname
    {
      get
      {
        return _hostname;
      }
      set
      {
        __isset.hostname = true;
        this._hostname = value;
      }
    }

    public string NetworkUserId
    {
      get
      {
        return _networkUserId;
      }
      set
      {
        __isset.networkUserId = true;
        this._networkUserId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool schema;
      public bool ipAddress;
      public bool timestamp;
      public bool encoding;
      public bool collector;
      public bool userAgent;
      public bool refererUri;
      public bool path;
      public bool querystring;
      public bool body;
      public bool headers;
      public bool contentType;
      public bool hostname;
      public bool networkUserId;
    }

    public CollectorPayload() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 31337:
              if (field.Type == TType.String) {
                Schema = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 100:
              if (field.Type == TType.String) {
                IpAddress = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 200:
              if (field.Type == TType.I64) {
                Timestamp = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 210:
              if (field.Type == TType.String) {
                Encoding = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 220:
              if (field.Type == TType.String) {
                Collector = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 300:
              if (field.Type == TType.String) {
                UserAgent = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 310:
              if (field.Type == TType.String) {
                RefererUri = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 320:
              if (field.Type == TType.String) {
                Path = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 330:
              if (field.Type == TType.String) {
                Querystring = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 340:
              if (field.Type == TType.String) {
                Body = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 350:
              if (field.Type == TType.List) {
                {
                  Headers = new List<string>();
                  TList _list0 = iprot.ReadListBegin();
                  for( int _i1 = 0; _i1 < _list0.Count; ++_i1)
                  {
                    string _elem2;
                    _elem2 = iprot.ReadString();
                    Headers.Add(_elem2);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 360:
              if (field.Type == TType.String) {
                ContentType = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 400:
              if (field.Type == TType.String) {
                Hostname = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 410:
              if (field.Type == TType.String) {
                NetworkUserId = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("CollectorPayload");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (IpAddress != null && __isset.ipAddress) {
          field.Name = "ipAddress";
          field.Type = TType.String;
          field.ID = 100;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(IpAddress);
          oprot.WriteFieldEnd();
        }
        if (__isset.timestamp) {
          field.Name = "timestamp";
          field.Type = TType.I64;
          field.ID = 200;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(Timestamp);
          oprot.WriteFieldEnd();
        }
        if (Encoding != null && __isset.encoding) {
          field.Name = "encoding";
          field.Type = TType.String;
          field.ID = 210;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Encoding);
          oprot.WriteFieldEnd();
        }
        if (Collector != null && __isset.collector) {
          field.Name = "collector";
          field.Type = TType.String;
          field.ID = 220;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Collector);
          oprot.WriteFieldEnd();
        }
        if (UserAgent != null && __isset.userAgent) {
          field.Name = "userAgent";
          field.Type = TType.String;
          field.ID = 300;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(UserAgent);
          oprot.WriteFieldEnd();
        }
        if (RefererUri != null && __isset.refererUri) {
          field.Name = "refererUri";
          field.Type = TType.String;
          field.ID = 310;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(RefererUri);
          oprot.WriteFieldEnd();
        }
        if (Path != null && __isset.path) {
          field.Name = "path";
          field.Type = TType.String;
          field.ID = 320;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Path);
          oprot.WriteFieldEnd();
        }
        if (Querystring != null && __isset.querystring) {
          field.Name = "querystring";
          field.Type = TType.String;
          field.ID = 330;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Querystring);
          oprot.WriteFieldEnd();
        }
        if (Body != null && __isset.body) {
          field.Name = "body";
          field.Type = TType.String;
          field.ID = 340;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Body);
          oprot.WriteFieldEnd();
        }
        if (Headers != null && __isset.headers) {
          field.Name = "headers";
          field.Type = TType.List;
          field.ID = 350;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.String, Headers.Count));
            foreach (string _iter3 in Headers)
            {
              oprot.WriteString(_iter3);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (ContentType != null && __isset.contentType) {
          field.Name = "contentType";
          field.Type = TType.String;
          field.ID = 360;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ContentType);
          oprot.WriteFieldEnd();
        }
        if (Hostname != null && __isset.hostname) {
          field.Name = "hostname";
          field.Type = TType.String;
          field.ID = 400;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Hostname);
          oprot.WriteFieldEnd();
        }
        if (NetworkUserId != null && __isset.networkUserId) {
          field.Name = "networkUserId";
          field.Type = TType.String;
          field.ID = 410;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(NetworkUserId);
          oprot.WriteFieldEnd();
        }
        if (Schema != null && __isset.schema) {
          field.Name = "schema";
          field.Type = TType.String;
          field.ID = 31337;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Schema);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("CollectorPayload(");
      bool __first = true;
      if (Schema != null && __isset.schema) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Schema: ");
        __sb.Append(Schema);
      }
      if (IpAddress != null && __isset.ipAddress) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("IpAddress: ");
        __sb.Append(IpAddress);
      }
      if (__isset.timestamp) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Timestamp: ");
        __sb.Append(Timestamp);
      }
      if (Encoding != null && __isset.encoding) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Encoding: ");
        __sb.Append(Encoding);
      }
      if (Collector != null && __isset.collector) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Collector: ");
        __sb.Append(Collector);
      }
      if (UserAgent != null && __isset.userAgent) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("UserAgent: ");
        __sb.Append(UserAgent);
      }
      if (RefererUri != null && __isset.refererUri) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("RefererUri: ");
        __sb.Append(RefererUri);
      }
      if (Path != null && __isset.path) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Path: ");
        __sb.Append(Path);
      }
      if (Querystring != null && __isset.querystring) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Querystring: ");
        __sb.Append(Querystring);
      }
      if (Body != null && __isset.body) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Body: ");
        __sb.Append(Body);
      }
      if (Headers != null && __isset.headers) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Headers: ");
        __sb.Append(Headers);
      }
      if (ContentType != null && __isset.contentType) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ContentType: ");
        __sb.Append(ContentType);
      }
      if (Hostname != null && __isset.hostname) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Hostname: ");
        __sb.Append(Hostname);
      }
      if (NetworkUserId != null && __isset.networkUserId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("NetworkUserId: ");
        __sb.Append(NetworkUserId);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
