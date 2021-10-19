# Slacker.NET

A super simple .NET Core library for building and sending Slack [BlockKit](https://api.slack.com/block-kit) payloads.
<br />
<br />
Test your payloads using the [BlockKit Builder.](https://app.slack.com/block-kit-builder/T04MVNZB6#%7B%22blocks%22:%5B%7B%22type%22:%22section%22,%22text%22:%7B%22type%22:%22mrkdwn%22,%22text%22:%22Hello,%20Assistant%20to%20the%20Regional%20Manager%20Dwight!%20*Michael%20Scott*%20wants%20to%20know%20where%20you'd%20like%20to%20take%20the%20Paper%20Company%20investors%20to%20dinner%20tonight.%5Cn%5Cn%20*Please%20select%20a%20restaurant:*%22%7D%7D,%7B%22type%22:%22divider%22%7D,%7B%22type%22:%22section%22,%22text%22:%7B%22type%22:%22mrkdwn%22,%22text%22:%22*Farmhouse%20Thai%20Cuisine*%5Cn:star::star::star::star:%201528%20reviews%5Cn%20They%20do%20have%20some%20vegan%20options,%20like%20the%20roti%20and%20curry,%20plus%20they%20have%20a%20ton%20of%20salad%20stuff%20and%20noodles%20can%20be%20ordered%20without%20meat!!%20They%20have%20something%20for%20everyone%20here%22%7D,%22accessory%22:%7B%22type%22:%22image%22,%22image_url%22:%22https://s3-media3.fl.yelpcdn.com/bphoto/c7ed05m9lC2EmA3Aruue7A/o.jpg%22,%22alt_text%22:%22alt%20text%20for%20image%22%7D%7D,%7B%22type%22:%22section%22,%22text%22:%7B%22type%22:%22mrkdwn%22,%22text%22:%22*Kin%20Khao*%5Cn:star::star::star::star:%201638%20reviews%5Cn%20The%20sticky%20rice%20also%20goes%20wonderfully%20with%20the%20caramelized%20pork%20belly,%20which%20is%20absolutely%20melt-in-your-mouth%20and%20so%20soft.%22%7D,%22accessory%22:%7B%22type%22:%22image%22,%22image_url%22:%22https://s3-media2.fl.yelpcdn.com/bphoto/korel-1YjNtFtJlMTaC26A/o.jpg%22,%22alt_text%22:%22alt%20text%20for%20image%22%7D%7D,%7B%22type%22:%22section%22,%22text%22:%7B%22type%22:%22mrkdwn%22,%22text%22:%22*Ler%20Ros*%5Cn:star::star::star::star:%202082%20reviews%5Cn%20I%20would%20really%20recommend%20the%20%20Yum%20Koh%20Moo%20Yang%20-%20Spicy%20lime%20dressing%20and%20roasted%20quick%20marinated%20pork%20shoulder,%20basil%20leaves,%20chili%20&%20rice%20powder.%22%7D,%22accessory%22:%7B%22type%22:%22image%22,%22image_url%22:%22https://s3-media2.fl.yelpcdn.com/bphoto/DawwNigKJ2ckPeDeDM7jAg/o.jpg%22,%22alt_text%22:%22alt%20text%20for%20image%22%7D%7D,%7B%22type%22:%22divider%22%7D,%7B%22type%22:%22actions%22,%22elements%22:%5B%7B%22type%22:%22button%22,%22text%22:%7B%22type%22:%22plain_text%22,%22text%22:%22Farmhouse%22,%22emoji%22:true%7D,%22value%22:%22click_me_123%22%7D,%7B%22type%22:%22button%22,%22text%22:%7B%22type%22:%22plain_text%22,%22text%22:%22Kin%20Khao%22,%22emoji%22:true%7D,%22value%22:%22click_me_123%22,%22url%22:%22https://google.com%22%7D,%7B%22type%22:%22button%22,%22text%22:%7B%22type%22:%22plain_text%22,%22text%22:%22Ler%20Ros%22,%22emoji%22:true%7D,%22value%22:%22click_me_123%22,%22url%22:%22https://google.com%22%7D%5D%7D%5D%7D) 

## New in 0.0.5
Added ButtonArray(Actions) to BlockKit payloads.

## Installation

https://www.nuget.org/packages/Slacker.NET.Library/

## Usage

Building and sending a BlockKit payload:
```csharp
using Slacker.NET.Library.Models;

// Create a new BlockPayload
BlockPayload blockKitPayload= new();

// Add whatever sections you'd like
blockKitPayload.AddHeader("It's almost Halloween!");
blockKitPayload.AddPlainText("Are you excited for the spooky season?");
blockKitPayload.AddMrkdwn("We're having a costume party this year! :ghost: *BOO!* Please bring...");

List<TextField> textFields = new();
textFields.Add(new TextField("Beef Tacos"));
textFields.Add(new TextField("Chicken Tacos"));
textFields.Add(new TextField("Fish Tacos"));
blockKitPayload.AddTextFields(textFields);

blockKitPayload.AddLinkButton("More Info", "https://www.google.com", "More info online!");
blockKitPayload.AddImageWithTitle("https://assets3.thrillist.com/v1/image/1682388/size/tl-horizontal_main.jpg", "Two Tacos!", "Two Tacos?");
blockKitPayload.AddDivider();

bool success = blockKitPayload.Send(new Uri(webhookUri));
// or
bool success = await blockKitPayload.SendAsync(new Uri(webhookUri));
```
Here's our completed BlockKit payload<br />
![Here's our BlockKit payload](https://github.com/bleichroeder/Slacker.NET/blob/main/Payload%20Examples/Images/BlockKitTacos.jpg?raw=true)

Creating and sending a SimpleMessage payload
````csharp
SimpleMessage simpleMessagePayload = new("This is a simple message payload.");

bool success = simpleMessagePayload.Send(new Uri(webhookUri));
// or
bool success = await simpleMessagePayload.SendAsync(new Uri(webhookUri));
````
## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://licenses.nuget.org/MIT)
