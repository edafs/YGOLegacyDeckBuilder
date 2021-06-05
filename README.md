# Yugioh Legacy Deck Builder

In development... This is not ready yet.

Deck Building service that provides information about a status legality of a card. This is to be intended to used to help with deckbuilding with legacy card formats.

---

## Setup


### Database

This application will be using mySQL for the back end. This will then be consumed by an AmazonRDS service.

#### mySQL Installation

- [Community edition](https://dev.mysql.com/downloads/mysql/) will suffice for local development, and it's free.
- [Workbench](https://dev.mysql.com/downloads/workbench/) is a GUI tool for managing your SQL instance.

#### AmazonRDS Instance

- [AmazonRDS for mySQL](https://aws.amazon.com/rds/mysql/) will be the cloud instance of this.
- Our db will light, and this is the cheapest option, offering a `db.t3.micro` instance.



### Application

Application runs on .NET Core 3.1.

#### dotNet Installations

- It is recommended to use [Visual Studio](https://visualstudio.microsoft.com/downloads/), the Community Edition is free.
- Install the [.NET core 3.1 SDK and Runtimes](https://dotnet.microsoft.com/download/dotnet/3.1)

#### SSL Keys

You may need to create new HTTPS keys on your machine in order to create a working API project.

On a Mac, you might already have expired ones. If so, open **KeyChain Access**. From there, look at your **login** and **system** under keychains. For both of those, look under **Certificates** and **My Certificates**. Delete any expired certificates.

To create a trusted development SSL certificate, run the following command in your terminal:

```bash
dotnet dev-certs https --trust
```



---

## API Guide

This app relies heavily on the YGOPRODeck's API service. Useful APIs that we will be using:

- Api Guide [Help](https://db.ygoprodeck.com/api-guide/)
- Card from a Set [Api](https://db.ygoprodeck.com/api/v7/cardsetsinfo.php?setcode=SDY-046)
- All Card Sets [API](https://db.ygoprodeck.com/api/v7/cardsets.php)
- One Card Info [Api](https://db.ygoprodeck.com/api/v7/cardinfo.php?id=57774843)
- All cards [Api](https://db.ygoprodeck.com/api/v7/cardinfo.php)



## Banlists

This will eventually be a service that determines the legality of certain cards. Current roadmap is to determine the legality of following:

- [In Progress] Sept 2011
  - [Banlist](https://yugioh.fandom.com/wiki/September_2011_Lists_(TCG)) 
  - Sept 01, 2011 - Feb 28, 2012
- [Future] Edison
  -  [BanList](https://yugioh.fandom.com/wiki/March_2010_Lists_(TCG))
  - March 01, 2010 - Aug 31, 2010
