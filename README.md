# Napier Bank Message Filtering Service

## Module Information

- **Module Number:** SET09102
- **Module Title:** Software Engineering

## Assessment Overview

This project involves developing a **Napier Bank Messaging (NBM) Service** that validates, sanitizes, and categorizes incoming messages in the form of SMS text messages, emails, and Tweets. The project includes the development of a prototype, a detailed software development report, and a video demonstration of the prototype.

## Submission Details

- **Deadline:** Friday, 25 November 2022, 15:00
- **Submission Format:** A zipped file containing:
  - Source code
  - Text output
  - Report
  - Video demo (non-submission of the video demo will result in a mark of 0)

## Project Requirements

### Message Types

The NBM service must handle the following types of messages:

1. **SMS Messages:**
   - Composed of a sender's international phone number and message text (max 140 characters).
   - Text may contain "textspeak abbreviations" that must be expanded.

2. **Email Messages:**
   - Standard email format with sender, subject (20 characters), and message text (max 1028 characters).
   - Two types:
     - **Standard Emails:** URLs in the text must be quarantined and replaced with `<URL Quarantined>`.
     - **Significant Incident Reports (SIRs):** Contain a specific subject format and start with a standard text. Specific details like `Sort Code` and `Nature of Incident` must be extracted.

3. **Tweets:**
   - Composed of a Twitter ID and tweet text (max 140 characters).
   - May contain textspeak abbreviations, hashtags, and mentions.

### System Functionality

The system should:
- Identify the message type automatically.
- Output each message in JSON format.
- Handle input through a user interface or an input file.
- Display trending hashtags, mentions, and a list of Significant Incident Reports (SIRs) after processing.

### Tasks and Deliverables

1. **Requirement Analysis:**
   - Specify requirements using a Use Case diagram, including Non-Functional Requirements (NFRs).

2. **System Design:**
   - Develop a class diagram illustrating necessary classes, methods, attributes, and relationships.

3. **Prototype Development:**
   - Implement a WPF application in C# (other languages such as Java are acceptable).
   - The system must also read messages from a text file, process them, and display them one-by-one.

4. **Testing:**
   - Develop a test plan covering objectives, scope, test cases, and testing methods.
   - Conduct tests to verify message processing for each type of message.

5. **Version Control:**
   - Propose a plan to use version control to support development and collaboration.

6. **Evolution Strategy:**
   - Prepare a strategy for system evolution, including maintainability, predicted costs, and evolution processes.

### Submission Deliverables

1. **Software Development Report:** (50 Marks)
   - Minimum of 8 pages, including diagrams.
   - Should cover:
     - Requirement specification
     - Class diagram
     - Test plan and analysis
     - Version control plan
     - Evolution strategy

2. **Prototype:** (40 Marks)
   - Functional system implementation.
   - Consideration of look and feel.
   - Code quality (format, clarity, comments).

3. **Visual Demo:** (10 Marks)
   - A 5-minute video demo explaining the app functionality.

## Marking Criteria

- **Software Development Report (50 Marks)**
  - Requirement specification: 10 marks
  - Class diagram: 10 marks
  - Testing (plan, methods, cases, outputs, analysis): 14 marks
  - Version control plan: 8 marks
  - Evolution strategy: 8 marks

- **Prototype (40 Marks)**
  - Functionality: 25 marks
  - Look and feel: 10 marks
  - Code clarity: 5 marks

- **Visual Demo (10 Marks)**

**Total: 100 Marks**
