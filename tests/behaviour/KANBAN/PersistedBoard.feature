Feature: PersistedBoard
	In order to persist work progress
	As a project manager
	I want to save and load board state on disk

Scenario: Board is saved on disk
	Given closed list has 'Chatbot' task with impact 4 ease 1 confidence 2
	And closed list has 'Dashboard' task with impact 8 ease 7 confidence 5
	And closed list has 'Mobile' task with impact 4 ease 3 confidence 9
	And closed WIP is 8
	And resolved list has 'AI for chatbot' task with impact 9 ease 1 confidence 1
	And resolved list has 'Design for dashboard' task with impact 2 ease 5 confidence 9
	And resolved WIP is 5
	And in work list has 'Mobile auth' task with impact 9 ease 1 confidence 9
	And in work list has 'Mobile swipe history' task with impact 5 ease 2 confidence 7
	And in work WIP is 5
	And todo list has 'Chatbot Telegram channel' task with impact 1 ease 3 confidence 1
	And todo WIP is 5
	And backlog has 'Chatbot Skype channel' task with impact 2 ease 2 confidence 2
	And backlog has 'Chatbot WhatsApp channel' task with impact 9 ease 2 confidence 9
	And backlog has 'Chatbot Facebook channel' task with impact 7 ease 2 confidence 7
	And backlog has 'Dashboard KPI graph' task with impact 9 ease 2 confidence 4
	And backlog has 'Dashboard PM graph' task with impact 4 ease 2 confidence 4
	When I save board to tmp file
	Then tmp file contains '{"Backlog":[{"Confidence":2,"Ease":2,"Impact":2,"Name":"Chatbot Skype channel"},{"Confidence":9,"Ease":2,"Impact":9,"Name":"Chatbot WhatsApp channel"},{"Confidence":7,"Ease":2,"Impact":7,"Name":"Chatbot Facebook channel"},{"Confidence":4,"Ease":2,"Impact":9,"Name":"Dashboard KPI graph"},{"Confidence":4,"Ease":2,"Impact":4,"Name":"Dashboard PM graph"}],"Todo":[{"Confidence":1,"Ease":3,"Impact":1,"Name":"Chatbot Telegram channel"}],"InWork":[{"Confidence":9,"Ease":1,"Impact":9,"Name":"Mobile auth"},{"Confidence":7,"Ease":2,"Impact":5,"Name":"Mobile swipe history"}],"Resolved":[{"Confidence":1,"Ease":1,"Impact":9,"Name":"AI for chatbot"},{"Confidence":9,"Ease":5,"Impact":2,"Name":"Design for dashboard"}],"Closed":[{"Confidence":2,"Ease":1,"Impact":4,"Name":"Chatbot"},{"Confidence":5,"Ease":7,"Impact":8,"Name":"Dashboard"},{"Confidence":9,"Ease":3,"Impact":4,"Name":"Mobile"}],"TodoWIP":5,"InWorkWIP":5,"ResolvedWIP":5,"ClosedWIP":8}'

Scenario: Board is loaded from disk
	Given board doesnt exist
	And tmp file exists having '{"Backlog":[{"Confidence":2,"Ease":2,"Impact":2,"Name":"Chatbot Skype channel"},{"Confidence":9,"Ease":2,"Impact":9,"Name":"Chatbot WhatsApp channel"},{"Confidence":7,"Ease":2,"Impact":7,"Name":"Chatbot Facebook channel"},{"Confidence":4,"Ease":2,"Impact":9,"Name":"Dashboard KPI graph"},{"Confidence":4,"Ease":2,"Impact":4,"Name":"Dashboard PM graph"}],"Todo":[{"Confidence":1,"Ease":3,"Impact":1,"Name":"Chatbot Telegram channel"}],"InWork":[{"Confidence":9,"Ease":1,"Impact":9,"Name":"Mobile auth"},{"Confidence":7,"Ease":2,"Impact":5,"Name":"Mobile swipe history"}],"Resolved":[{"Confidence":1,"Ease":1,"Impact":9,"Name":"AI for chatbot"},{"Confidence":9,"Ease":5,"Impact":2,"Name":"Design for dashboard"}],"Closed":[{"Confidence":2,"Ease":1,"Impact":4,"Name":"Chatbot"},{"Confidence":5,"Ease":7,"Impact":8,"Name":"Dashboard"},{"Confidence":9,"Ease":3,"Impact":4,"Name":"Mobile"}],"TodoWIP":5,"InWorkWIP":5,"ResolvedWIP":5,"ClosedWIP":8}'
	When tmp file is loaded to board
	Then board exists
	And closed list has 'Chatbot' task with impact 4 ease 1 confidence 2
	And closed list has 'Dashboard' task with impact 8 ease 7 confidence 5
	And closed list has 'Mobile' task with impact 4 ease 3 confidence 9
	And closed WIP is 8
	And resolved list has 'AI for chatbot' task with impact 9 ease 1 confidence 1
	And resolved list has 'Design for dashboard' task with impact 2 ease 5 confidence 9
	And resolved WIP is 5
	And in work list has 'Mobile auth' task with impact 9 ease 1 confidence 9
	And in work list has 'Mobile swipe history' task with impact 5 ease 2 confidence 7
	And in work WIP is 5
	And todo list has 'Chatbot Telegram channel' task with impact 1 ease 3 confidence 1
	And todo WIP is 5
	And backlog has 'Chatbot Skype channel' task with impact 2 ease 2 confidence 2
	And backlog has 'Chatbot WhatsApp channel' task with impact 9 ease 2 confidence 9
	And backlog has 'Chatbot Facebook channel' task with impact 7 ease 2 confidence 7
	And backlog has 'Dashboard KPI graph' task with impact 9 ease 2 confidence 4
	And backlog has 'Dashboard PM graph' task with impact 4 ease 2 confidence 4