# Documenting Architectures

<b>Quality Views</b>

Target specific kinds of information
- Security
- Communication Structure
- Error Handling
- Reliability
- Performance

Security:
- Roles in the system
- Encryption on communication protocols
- How to handle threats as vulnerabilities

Communication:
- Channels (Different communication styles through the system. Is it all the same or are some pub/sub and or client-server)

Error Handling:
- How to detect, report and resolve

Reliability:
- Replicas

Performance:
- Caching,
- Buffering etc.
___

<br>
An architecture may require behavior documentation describing how elements interact with eachother (Described through traces and comprehensive notation)

- Usecase diagrams (trace)
- Sequence diagrams (trace)
- Communication diagrams (trace)
- Activity diagrams (trace)
- State machine diagrams (Comprehensive)
___

<b>Variability Guide</b> <br>
Shows how the system are able to change.
Some things change some don't. We want to document what is steady and does not change. This could be an interface that should not change.
What stays throughout the change should be documented.
___
<b>Documenting Rationale</b> <br>
Document important design choices. Why were event driven communication chosen over direct service to service communication as an example. It helps new members understand the architecture
___
