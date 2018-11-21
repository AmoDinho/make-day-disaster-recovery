using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auth {
	public const string RootURL = "https://sandbox.root.co.za/v1/insurance";

	public string GetAuthKey()
	{
		string APIKey = "sandbox_OWViNDNkY2QtYjhiYi00YTg4LTg2ZmQtZWM1YmU0MTEzMWI4LkhadE1pSVlrOGhScmpiT2pJdW1NeVE3aXpneW51NWlY";

		if (string.IsNullOrEmpty(APIKey))
		{
			throw new Exception("APIKey cannot be empty");
		}

		string auth = APIKey + ":";
		string encodedAuth = System.Convert.ToBase64String(
			System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth)
		);
		string readyAuth = "Basic " + encodedAuth;

		return readyAuth;
	}
}
