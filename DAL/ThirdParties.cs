using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace test
{
   public class ThirdParties: DB
   {
      public int MODO {get; set;}
      public Int32 ID{ get; set;}
      public String FirstName{ get; set;}
      public String LastName{ get; set;}
      public Int32 DocumentTypeID{ get; set;}
      public String DocumentNumber{ get; set;}
      public String CityIataCode{ get; set;}
      public String PhoneNumber{ get; set;}
      public String FaxNumber{ get; set;}
      public String Address{ get; set;}
      public String MobilePhoneNumber{ get; set;}
      public String Email{ get; set;}
      public Int32 CountryID{ get; set;}
      public Int32 VerificationDigit{ get; set;}
      public ThirdParties()
      {
         ID = 0;
         FirstName = null;
         LastName = null;
         DocumentTypeID = 0;
         DocumentNumber = null;
         CityIataCode = null;
         PhoneNumber = null;
         FaxNumber = null;
         Address = null;
         MobilePhoneNumber = null;
         Email = null;
         CountryID = 0;
         VerificationDigit = 0;
      }

	public DataSet PRC_ThirdParties()
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

		SqlParameter FirstNameParameter=new SqlParameter("@FirstName",SqlDbType.VarChar);
		FirstNameParameter.Size=200;
		FirstNameParameter.Value=FirstName;
		Parameters.Add(FirstNameParameter);

		SqlParameter LastNameParameter=new SqlParameter("@LastName",SqlDbType.VarChar);
		LastNameParameter.Size=200;
		LastNameParameter.Value=LastName;
		Parameters.Add(LastNameParameter);

		SqlParameter DocumentTypeIDParameter=new SqlParameter("@DocumentTypeID",SqlDbType.Int);
		DocumentTypeIDParameter.Size=0;
		DocumentTypeIDParameter.Value=DocumentTypeID;
		Parameters.Add(DocumentTypeIDParameter);

		SqlParameter DocumentNumberParameter=new SqlParameter("@DocumentNumber",SqlDbType.VarChar);
		DocumentNumberParameter.Size=50;
		DocumentNumberParameter.Value=DocumentNumber;
		Parameters.Add(DocumentNumberParameter);

		SqlParameter CityIataCodeParameter=new SqlParameter("@CityIataCode",SqlDbType.VarChar);
		CityIataCodeParameter.Size=5;
		CityIataCodeParameter.Value=CityIataCode;
		Parameters.Add(CityIataCodeParameter);

		SqlParameter PhoneNumberParameter=new SqlParameter("@PhoneNumber",SqlDbType.VarChar);
		PhoneNumberParameter.Size=50;
		PhoneNumberParameter.Value=PhoneNumber;
		Parameters.Add(PhoneNumberParameter);

		SqlParameter FaxNumberParameter=new SqlParameter("@FaxNumber",SqlDbType.VarChar);
		FaxNumberParameter.Size=50;
		FaxNumberParameter.Value=FaxNumber;
		Parameters.Add(FaxNumberParameter);

		SqlParameter AddressParameter=new SqlParameter("@Address",SqlDbType.VarChar);
		AddressParameter.Size=100;
		AddressParameter.Value=Address;
		Parameters.Add(AddressParameter);

		SqlParameter MobilePhoneNumberParameter=new SqlParameter("@MobilePhoneNumber",SqlDbType.VarChar);
		MobilePhoneNumberParameter.Size=50;
		MobilePhoneNumberParameter.Value=MobilePhoneNumber;
		Parameters.Add(MobilePhoneNumberParameter);

		SqlParameter EmailParameter=new SqlParameter("@Email",SqlDbType.VarChar);
		EmailParameter.Size=50;
		EmailParameter.Value=Email;
		Parameters.Add(EmailParameter);

		SqlParameter CountryIDParameter=new SqlParameter("@CountryID",SqlDbType.Int);
		CountryIDParameter.Size=0;
		CountryIDParameter.Value=CountryID;
		Parameters.Add(CountryIDParameter);

		SqlParameter VerificationDigitParameter=new SqlParameter("@VerificationDigit",SqlDbType.Int);
		VerificationDigitParameter.Size=0;
		VerificationDigitParameter.Value=VerificationDigit;
		Parameters.Add(VerificationDigitParameter);

		 DataSet dsResult=ExecuteStoredProcedure("[dbo].[PRC_ThirdParties]",ref Parameters);

		return dsResult;
	}
   }
}
