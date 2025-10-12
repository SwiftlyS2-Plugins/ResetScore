<div align="center">
  <img src="https://cdn.swiftlys2.net/branding/text/v1_brand_color.png" />
  <h2><strong>ResetScore</strong></h2>
  <h3>A simple ResetScore plugin made for SwiftlyS2.</h3>
</div>

<p align="center">
  <img src="https://img.shields.io/badge/build-passing-brightgreen" alt="Build Status">
  <img src="https://img.shields.io/github/downloads/SwiftlyS2-Plugins/ResetScore/total" alt="Downloads">
  <img src="https://img.shields.io/github/stars/SwiftlyS2-Plugins/ResetScore?style=flat&logo=github" alt="Stars">
  <img src="https://img.shields.io/github/license/SwiftlyS2-Plugins/ResetScore" alt="License">
</p>

# ResetScore

A SwiftlyS2 plugin that lets you reset your scoreboard stats.

## Installation


## Configuration

After you start the plugin once, the configuration file will be generated inside `addons/swiftlys2/configs/plugins/resources/config.jsonc`.

The structure looks like this
```
{
  "Main": {
    "Prefix": "[red]SWIFTLY [/] | ",
    "Commands": [
      "rs",
      "resetscore",
      "reset",
      "rsc"
    ]
  }
}
```

Change `Prefix` to whatever you want the prefix to be.