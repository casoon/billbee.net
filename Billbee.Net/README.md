Billbee.Net is a modern and asynchronous .Net client library based on Flurl and Polly.

## GOAL

.NET8 client support for Billbee API

## CONFIGURE / How To Use

Get it on NuGet:

`PM> Install-Package Billbee.Net`

For use in your .Net projects just add a reference to your startUp class and good to go.

Add Billbee URL, ApiKey, Username, and Password to your configuration

  "Billbee": {
    "Url": "https://app.billbee.io/api/v1",
    "ApiKey": "YOUR_API_KEY",
    "Username": "YOUR_USERNAME",
    "Password": "YOUR_PASSWORD",
    "Logging": "false"
  }

register service in startUp or program file by adding services.RegisterBillbee(ICONFIGURATION)

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE) file for more info.  