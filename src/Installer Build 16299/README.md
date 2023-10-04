# Update a certificate

1. Right click Installer Build 16299 > Publish > Create App Package ...
2. Leave Sideloading checked, don't enable automatic updates, Next
3. Remove old cert, Select From Store > Next
4. Swap x86 Solution Configuration from 'Debug (x86)' to 'Release(x86)'
5. Create

# More details
Check for emails from dipeshv@neximcare.ca for historical instructions.

Instructions for end user:
```
to install the new cert:
you'll need to right click 'Installer Build 16299_0.6.6.0_x86.cer' and select 'Install Certificate'. In the new window, click next, then 'Place all certificates in the following store', then 'Browse...', and select Trusted Root Certification Authorities. Then click OK, and Next, and Finish.
```

# .NET framework version 4.8
Support for .NET framework 4.7.2 will go away at some point. You can go into all the 'projects' (e.g. QBConnect) and press alt-enter, or right click and go to properties to specify the Target Framework. Afterwards, you might have trouble locating the old .dlls like QBFC13. To add back, right click the app and 'Add -> Reference', then specifically pick the .dll (any really) for QBFC13. For dependent projects that can't find sub projects (e.g. MCBusinessLogic not finding QBConnect, you can re-checkmark in the Reference manager after right clicking 'Add -> References'