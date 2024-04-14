using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace test
{
   public class IdentificationDocuments: DB
   {
      public int MODO {get; set;}
      public Int32 ID{ get; set;}
      public String Name{ get; set;}
      public IdentificationDocuments()
      {
         ID = 0;
         Name = null;
      }

	public DataSet PRC_IdentificationDocuments()
	{
		ArrayList Parameters=new ArrayList(0);

		SqlParameter MODOParameter=new SqlParameter("@MODO",SqlDbType.Int);
		MODOParameter.Size=0;
		MODOParameter.Value=MODO;
		Parameters.Add(MODOParameter);

		SqlParameter IDParameter=new SqlParameter("@ID",SqlDbType.Int);
		IDParameter.Size=0;
		IDParameter.Value=ID;
		Parameters.Add(IDParameter);

		SqlParameter NameParameter=new SqlParameter("@Name",SqlDbType.VarChar);
		NameParameter.Size=65;
		NameParameter.Value=Name;
		Parameters.Add(NameParameter);

		 DataSet dsResult=ExecuteStoredProcedure("[dbo].[PRC_IdentificationDocuments]",ref Parameters);

		return dsResult;
	}
   }
}
