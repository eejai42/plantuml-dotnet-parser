<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:param name="output-filename" select="'output.txt'" />

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>

    <xsl:template match="/*">
        <FileSet>
            <FileSetFiles>
                <xsl:for-each select="//PlantTextFiles/PlantTextFile">
                <FileSetFile>
                    <RelativePath>
                        <xsl:value-of select="Name" />
                        <xsl:text>.txt</xsl:text>                        
                    </RelativePath>
                    <OverwriteMode>Never</OverwriteMode>
                    <xsl:element name="FileContents" xml:space="preserve"><xsl:value-of select="PlantText"/>
</xsl:element>
                </FileSetFile>
                </xsl:for-each>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
</xsl:stylesheet>
