using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace test
{
   public class Cities: DB
   {
      public int MODO {get; set;}
      public String IATACode{ get; set;}
      public String Name{ get; set;}
      public String CountryIATACode{ get; set;}
      public String StateName{ get; set;}
      public Cities()
      {
         IATACode = null;
         Name = null;
         CountryIATACode = null;
         StateName = null;
      }

	public DataSet PRC_Cities()
	{
		ArrayList Parameters=new ArrayList(0);

		SqlParameter MODOParameter=new SqlParameter("@MODO",SqlDbType.Int);
		MODOParameter.Size=0;
		MODOParameter.Value=MODO;
		Parameters.Add(MODOParameter);

		SqlParameter IATACodeParameter=new SqlParameter("@IATACode",SqlDbType.VarChar);
		IATACodeParameter.Size=5;
		IATACodeParameter.Value=IATACode;
		Parameters.Add(IATACodeParameter);

		SqlParameter NameParameter=new SqlParameter("@Name",SqlDbType.VarChar);
		NameParameter.Size=200;
		NameParameter.Value=Name;
		Parameters.Add(NameParameter);

		SqlParameter CountryIATACodeParameter=new SqlParameter("@CountryIATACode",SqlDbType.VarChar);
		CountryIATACodeParameter.Size=2;
		CountryIATACodeParameter.Value=CountryIATACode;
		Parameters.Add(CountryIATACodeParameter);

		SqlParameter StateNameParameter=new SqlParameter("@StateName",SqlDbType.VarChar);
		StateNameParameter.Size=50;
		StateNameParameter.Value=StateName;
		Parameters.Add(StateNameParameter);

		 DataSet dsResult=ExecuteStoredProcedure("[dbo].[PRC_Cities]",ref Parameters);

		return dsResult;
	}
   }
}
