using System;
using System.Web.Configuration;

public class AcessoDB
{
  static public String ConnectionString
  {
    get
    {   
      return WebConfigurationManager.ConnectionStrings["FEMSA"].ConnectionString;
    }
  }
}
