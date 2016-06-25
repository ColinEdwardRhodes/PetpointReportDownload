PetpointReportDownload
======================

An automated report downloader for petpoint.com using selenium and c#.

## Configuration Files

To run a report you must first setup a configuration file.  The configuration file specifies the name of the report and the fields that can be used within it.  A simple text format is used - tabs are important!

###Simple Sample Configuration File

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
#
# The name of the report has zero tabs in front of it.
#
Animal: Intake with Results Extended
    # the intake start date
    Intake Start Date:
    	# the name of the element on the report page.  Use chrome or IE inspect element ot get the CSS Path.
        //*[@id="calendar1_Date1"]
        # a default value
        03/20/2010
        # should we always use the default?
        False
    # The intake end date
    Intake End Date:
        //*[@id="calendar2_Date1"]
        03/20/2014
        False
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

###Advanced Sample Configuration File

Advanced configuration files can contain date ranges.  See %LAST_n% syntax comment below.
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Animal: Intake with Results Extended
	# the intake start date
	Intake Start Date
		//*[@id="calendar1_Date1"]
		# last 30 days
		%LAST_30%
		False
	# The intake end date
	Intake End Date
		//*[@id="calendar2_Date1"]
		# today
		%LAST_0%
		False
	
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

## Command Line

* /r - specify the report name
* /p - specify a parameter override value

### Sample
/p "Intake Start Date=%LAST_2%" /p "Intake End Date=%LAST_0%"  /r  ../../AnimalIntakeWithResultsExtended
