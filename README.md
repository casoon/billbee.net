# Billbee.Net

![Nuget](https://img.shields.io/nuget/v/Billbee.Net)
![Nuget](https://img.shields.io/nuget/dt/Billbee.Net)
![GitHub Workflow Status](https://img.shields.io/github/workflow/status/casoon/billbee.net/.NET)
![GitHub Release Date](https://img.shields.io/github/release-date/casoon/billbee.net)
[![HitCount](http://hits.dwyl.com/casoon/billbeenet.svg?style=flat-square)](http://hits.dwyl.com/casoon/billbeenet)

Billbee.Net is a modern and asynchronous .Net client library based on Flurl and Polly.


## GOAL

.NET6 client support for Billbee API

## CONFIGURE / How To Use

Get it on NuGet:

`PM> Install-Package Billbee.Net`

For use in your .Net projects just add a reference to your startUp class and good to go.

Add Billbee URL, ApiKey, Username, and Password to your configuration

{
  "BillbeeUrl": "https://app.billbee.io/api/v1",
  "ApiKey": "YOUR_API_KEY",
  "Username": "YOUR_USERNAME",
  "Password": "YOUR_PASSWORD"
}

register Service in StartUp or program file by adding services.RegisterBillbee(ICONFIGURATION)


## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE) file for more info.  
