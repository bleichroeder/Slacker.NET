# Slacker.NET

A basic .NET Core Slack BlockKit payload builder and simple message dispatcher.

## Usage

Building BlockKit payloads is as simple as creating a new BlockPayload and adding sections.
```csharp
// Create a new BlockPayload
BlockPayload blockKitPayload= new();

// Now we can add a header section
blockKitPayload.AddHeader("It's almost Halloween!");

// Add a PlainText section
blockKitPayload.AddPlainText("Are you excited for the spooky season?");

// Add a Mrkdwn section
blockKitPayload.AddMrkdwn("We're having a costume party this year! :ghost: *BOO!* Please bring...");

// Create a new list of TextFields and add a TextField section
List<TextField> textFields = new();
textFields.Add(new TextField("Beef Tacos"));
textFields.Add(new TextField("Chicken Tacos"));
textFields.Add(new TextField("Fish Tacos"));
blockKitPayload.AddTextFields(textFields);

// Add a basic LinkButton section
blockKitPayload.AddLinkButton("More Info", "https://www.google.com", "More info online!");

// Add an ImageWithTitle section
blockKitPayload.AddImageWithTitle("https://assets3.thrillist.com/v1/image/1682388/size/tl-horizontal_main.jpg", "Two Tacos!", "Two Tacos?");

// Add a divider section
blockKitPayload.AddDivider();
```
Simple text payloads are created similarly.
````csharp
// Create a new BlockKit payload
SimpleMessage simpleMessagePayload= new("This is a simple message payload.");
````
Send payloads using the Send() or SendAsync() methods.
```csharp
bool success = blockKitPayload.Send(new Uri(webhookUri));
bool success = simpleMessagePayload.Send(new Uri(webhookUri));

// or

bool success = await blockKitPayload.SendAsync(new Uri(webhookUri));
bool success = await simpleMessagePayload.SendAsync(new Uri(webhookUri));
````

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://licenses.nuget.org/MIT)
