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
                <FileSetFile>
                    <RelativePath>
                        <xsl:text>PlantUML.xml</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve"><PlantUML>
    <ParticipantTypes>
        <xsl:for-each select="//Keywords/Keyword[KeywordType='ParticipantType']"><xsl:sort select="SortOrder" data-type="number" />
            <xsl:apply-templates select="." mode="participanttype" />
        </xsl:for-each>
    </ParticipantTypes>
    <Keywords>
        <xsl:for-each select="//Keywords/Keyword[KeywordType='Keyword']"><xsl:sort select="SortOrder" data-type="number" />
            <xsl:apply-templates select="." mode="keyword" />
        </xsl:for-each>
    </Keywords>
    <Keywords>
        <xsl:for-each select="//TargetFormats/TargetFormat"><xsl:sort select="SortOrder" data-type="number" />
            <xsl:apply-templates select="." />
        </xsl:for-each>
    </Keywords>
    <SequenceTypes>
        <xsl:for-each select="//SequenceTypes/SequenceType"><xsl:sort select="SortOrder" data-type="number" />
            <xsl:apply-templates select="." />
        </xsl:for-each>
    </SequenceTypes>
    <PlantTextFiles>
        <xsl:for-each select="//PlantTextFiles/PlantTextFile"><xsl:sort select="SortOrder" data-type="number" />
            <xsl:apply-templates select="." />
        </xsl:for-each>
    </PlantTextFiles>
</PlantUML>
</xsl:element>
                </FileSetFile>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
    <xsl:template mode="participanttype" match="Keyword">
        <ParticipantType>
            <xsl:apply-templates select="Name" />
        </ParticipantType>
    </xsl:template>
    <xsl:template mode="keyword" match="Keyword">
        <Keyword>
            <xsl:apply-templates select="Name" />
        </Keyword>
    </xsl:template>
    <xsl:template match="TargetFormat">
        <TargetFormat>
            <xsl:apply-templates select="Name" />
            <xsl:apply-templates select="DisplayName" />
            <xsl:apply-templates select="IsUMLDiagram" />
        </TargetFormat>
    </xsl:template>
    <xsl:template  match="SequenceType">
        <SequenceType>
            <xsl:apply-templates select="Name" />
            <xsl:apply-templates select="SequenceIdentifier" mode="escape" />
            <xsl:apply-templates select="ReverseSequenceIdentifier" mode="escape" />
        </SequenceType>
    </xsl:template>

    <xsl:template  match="PlantTextFile">
        <PlantTextFile>
            <xsl:apply-templates select="Name" />
            <xsl:apply-templates select="PlantText" mode="escape" />
            <xsl:apply-templates select="ReverseSequenceIdentifier" mode="escape" />
            <Instructions>
                <xsl:for-each select="//Instructions/Instruction[PlantTextFile=current()/PlantTextFileId]"><xsl:sort select="SortOrder" data-type="number" />
                    <xsl:apply-templates select="." />>
                </xsl:for-each>
            </Instructions>
        </PlantTextFile>
    </xsl:template>

    <xsl:template  match="Instruction">
        <Instruction>
            <xsl:apply-templates mode="escape" select="Name" />
            <xsl:apply-templates mode="escape" select="InstructionType" />
            <xsl:apply-templates mode="escape" select="Sequence" />
            <xsl:apply-templates mode="escape" select="LeftParticipantName" />
            <xsl:apply-templates mode="escape" select="RightParticipantName" />
            <xsl:apply-templates mode="escape" select="AdditionalText" />
            <xsl:apply-templates mode="escape" select="UseAlternateInstructionFormat" />
            <xsl:apply-templates mode="escape" select="AlternateLeftParticipantName" />
            <xsl:apply-templates mode="escape" select="AlternatSequenceId" />
            <xsl:apply-templates mode="escape" select="AlternateRightParticipantName" />
            <xsl:apply-templates mode="escape" select="ExpectedPlantText" />
            <xsl:apply-templates mode="escape" select="LeftRightInstructionText" />
            <xsl:apply-templates mode="escape" select="DeclarationInstructionText" />
            <xsl:apply-templates mode="escape" select="SortOrder" />
        </Instruction>
    </xsl:template>

    






    <xsl:template match="*" mode="escape">
        <!-- Begin opening tag -->
        <xsl:text>&lt;</xsl:text>
        <xsl:value-of select="name()"/>

        <!-- Attributes -->
        <xsl:for-each select="@*">
            <xsl:text> </xsl:text>
            <xsl:value-of select="name()"/>
            <xsl:text>='</xsl:text>
            <xsl:call-template name="escape-xml">
                <xsl:with-param name="text" select="."/>
            </xsl:call-template>
            <xsl:text>'</xsl:text>
        </xsl:for-each>

        <!-- End opening tag -->
        <xsl:text>&gt;</xsl:text>

        <!-- Content (child elements, text nodes, and PIs) -->
        <xsl:apply-templates select="node()" mode="escape" />

        <!-- Closing tag -->
        <xsl:text>&lt;/</xsl:text>
        <xsl:value-of select="name()"/>
        <xsl:text>&gt;</xsl:text>
    </xsl:template>

    <xsl:template match="text()" mode="escape">
        <xsl:call-template name="escape-xml">
            <xsl:with-param name="text" select="."/>
        </xsl:call-template>
    </xsl:template>

    <xsl:template match="processing-instruction()" mode="escape">
        <xsl:text>&lt;?</xsl:text>
        <xsl:value-of select="name()"/>
        <xsl:text> </xsl:text>
        <xsl:call-template name="escape-xml">
            <xsl:with-param name="text" select="."/>
        </xsl:call-template>
        <xsl:text>?&gt;</xsl:text>
    </xsl:template>

    <xsl:template name="escape-xml">
        <xsl:param name="text"/>
        <xsl:if test="$text != ''">
            <xsl:variable name="head" select="substring($text, 1, 1)"/>
            <xsl:variable name="tail" select="substring($text, 2)"/>
            <xsl:choose>
                <xsl:when test="$head = '&amp;'">&amp;amp;</xsl:when>
                <xsl:when test="$head = '&lt;'">&amp;lt;</xsl:when>
                <xsl:when test="$head = '&gt;'">&amp;gt;</xsl:when>
                <xsl:when test="$head = '&quot;'">&amp;quot;</xsl:when>
                <xsl:when test="$head = &quot;&apos;&quot;">&amp;apos;</xsl:when>
                <xsl:otherwise><xsl:value-of select="$head"/></xsl:otherwise>
            </xsl:choose>
            <xsl:call-template name="escape-xml">
                <xsl:with-param name="text" select="$tail"/>
            </xsl:call-template>
        </xsl:if>
    </xsl:template>
</xsl:stylesheet>
