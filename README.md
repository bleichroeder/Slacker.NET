# Slacker.NET

A basic .NET Core Slack BlockKit payload builder and simple message dispatcher.

## Installation

https://www.nuget.org/packages/Slacker.NET.Library/

## Usage

Building and sending a BlockKit payload:
```csharp
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
