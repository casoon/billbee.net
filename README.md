# Billbee.Net


## GOAL

.NET6 client support for Billbee API

## CONFIGURE / How To Use

For use in your .Net projects.  Just add a reference to your startUp class and good to go

Add Billbee URL, ApiKey, Username, and Password to your configurations

{
  "BillbeeUrl": "https://app.billbee.io/api/v1",
  "ApiKey": "YOUR_API_KEY",
  "Username": "YOUR_USERNAME",
  "Password": "YOUR_PASSWORD"
}

register Service in StartUp or program file by adding services.RegisterBillbee(ICONFIGURATION)


## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE) file for more info.  
