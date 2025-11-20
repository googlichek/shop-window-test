# Unity Modular Shop Prototype

This is a simple implementation of a shop system in Unity where the main goal was to make everything as domain-agnostic as possible. Each domain (Health, Gold, Location, VIP, Shop) lives in isolation and communicates through the Core.

I approached this as a production-ready system rather than just a prototype, mainly focusing on designing the shop to work with any game resource without ever knowing what those resources actually are.

This means:

- Each domain lives in its own assembly definition and can't reference others
- The Shop domain has zero knowledge about health, gold, locations, or VIP status
- Adding new resource types requires no changes to existing domains
- The Core contains only truly universal abstractions

The PlayerData singleton in Core uses a generic storage system so it never needs specific knowledge about what domains exist. Each domain manages its own data within PlayerData.

For the visual side, I used a third-party scroll snap plugin to set up the bundle carousel as quickly as possible.

I also fake "purchase processing" with a 3-second delay between pressing a button and resources actually updating.
