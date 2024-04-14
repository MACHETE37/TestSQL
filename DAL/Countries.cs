using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace test
{
   public class Countries: DB
   {
      public int MODO {get; set;}
      public String IATACode{ get; set;}
      public String Name{ get; set;}
      public Int32 ID{ get; set;}
      public String DIANCode{ get; set;}
      public Countries()
      {
         IATACode = null;
         Name = null;
         ID = 0;
         DIANCode = null;
      }

	public DataSet PRC_Countries()
	{
		ArrayList Parameters=new ArrayList(0);

		SqlParameter MODOParameter=new SqlParameter("@MODO",SqlDbType.Int);
		MODOParameter.Size=0;
		MODOParameter.Value=MODO;
		Parameters.Add(MODOParameter);

		SqlParameter IATACodeParameter=new SqlParameter("@IATACode",SqlDbType.VarChar);
		IATACodeParameter.Size=2;
		IATACodeParameter.Value=IATACode;
		Parameters.Add(IATACodeParameter);

		SqlParameter NameParameter=new SqlParameter("@Name",SqlDbType.VarChar);
		NameParameter.Size=50;
		NameParameter.Value=Name;
		Parameters.Add(NameParameter);

		SqlParameter IDParameter=new SqlParameter("@ID",SqlDbType.Int);
		IDParameter.Size=0;
		IDParameter.Value=ID;
		Parameters.Add(IDParameter);

		SqlParameter DIANCodeParameter=new SqlParameter("@DIANCode",SqlDbType.VarChar);
		DIANCodeParameter.Size=50;
		DIANCodeParameter.Value=DIANCode;
		Parameters.Add(DIANCodeParameter);

		 DataSet dsResult=ExecuteStoredProcedure("[dbo].[PRC_Countries]",ref Parameters);

		return dsResult;
	}
   }
}
