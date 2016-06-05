# PetpointReportDownload
An automated report downloader for petpoint.com

## Simple Sample Configuration File

```
#
# The name of the report has zero tabs in front of it.
#
Animal: Intake with Results Extended
	# the intake start date
	Intake Start Date:
		//*[@id="calendar1_Date1"]
		03/20/2010
		False
	# The intake end date
	Intake End Date:
		//*[@id="calendar2_Date1"]
		03/20/2014
		False
```

## Complex Sample Configuration File with c# code

```
#
# The name of the report has zero tabs in front of it.
#
Animal: Intake with Results Extended
	# the intake start date
	Intake Start Date:
		//*[@id="calendar1_Date1"]
		(DateTime.Now).ToString("MM/dd/yy");
		False
	# The intake end date
	Intake End Date:
		//*[@id="calendar2_Date1"]
		(DateTime.Now - 30).ToString("MM/dd/yy");
		False
```
