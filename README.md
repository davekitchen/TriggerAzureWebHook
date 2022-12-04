# Simple Trigger Azure WebHook Using C#

Use Case:

You have a Web Job or other Azure service which can be activated by triggering your Azure Webhook. 

You want to perform this activation in a c# function using .Net 6 or higher and using commands which haven’t been deprecated.

This is a working example. However, please note the Webjob being called here was deleted before posing so you will get a 404 error. Replace the parameters with those provided by the Azure dashbord for your own Web Job.

Solution:

Everything you want to see is contained within the Program.cs file.

Comment:

When you go live with your code I don't recomend hard coding credentials as per this example.
04-12-2022 Microsoft love to provide webhooks ....

triggeredwebjobs/<functionname>/start

these normally don't work so try:

triggeredwebjobs/<functionname>/run
