Feature: Board task pipe
	In order to keep track of tasks statuses and even raise performance
	As a project manager
	I want to see feature statuses in columns of kanban board

Scenario: Add task to backlog
	Given backlog having 4 tasks
	When adding task to backlog
	Then backlog having 5 tasks

Scenario: Add task to empty backlog
	Given backlog having 0 tasks
	When adding task to backlog
	Then backlog having 1 tasks

Scenario: Remove task from backlog
	Given backlog having 4 tasks
	When removing task from backlog
	Then backlog having 3 tasks

Scenario: Promote task from backlog to not full todo list
	Given backlog having 4 tasks and todo list having 3 tasks
	And todo column WIP is 5
	When promote task from backlog to todo list
	Then backlog having 3 tasks
	And todo list having 4 tasks

Scenario: Promote task from backlog to full todo list
	Given backlog having 4 tasks and todo list having 5 tasks
	And todo column WIP is 5
	When promote task from backlog to todo list
	Then backlog having 4 tasks 
	And todo list having 5 tasks
	And WIP is full exception is raised

Scenario: Drop task from todo list
	Given backlog having 4 tasks and todo list having 4 tasks
	When drop task from todo list
	Then todo list having 3 tasks
	And backlog having 5 tasks

Scenario: Promote task from todo list to not full in work list
	Given todo list having 4 tasks and in work list having 3 tasks
	And in work column WIP is 5
	When promote task from todo list to in work list
	Then todo list having 3 tasks
	And in work list having 4 tasks

Scenario: Promote task from todo list to full in work list
	Given todo list having 4 tasks and in work list having 5 tasks
	And in work column WIP is 5
	When promote task from todo list to in work list
	Then todo list having 4 tasks
	And in work list having 5 tasks
	And WIP is full exception is raised

Scenario: Promote task from in work list to not full resolved list
	Given in work list having 3 tasks and resolved list having 3 tasks
	And resolved column WIP is 5
	When promote task from in work list to resolved list
	Then in work list having 2 tasks
	And resolved list having 4 tasks

Scenario: Promote task from in work list to full resolved list
	Given in work list having 4 tasks and resolved list having 5 tasks
	And resolved column WIP is 5
	When promote task from in work list to resolved list
	Then in work list having 4 tasks
	And resolved list having 5 tasks
	And WIP is full exception is raised


Scenario: Drop task from in work list to not full todo list
	Given todo list having 4 tasks and in work list having 4 tasks
	And todo column WIP is 5
	When drop task from in work list
	Then todo list having 5 tasks
	And in work list having 3 tasks

Scenario: Drop task from in work list to full todo list
	Given todo list having 5 tasks and in work list having 4 tasks
	And todo column WIP is 5
	When drop task from in work list
	Then todo list having 5 tasks
	And in work list having 4 tasks
	And WIP is full exception is raised

Scenario: Promote task from resolved list to not full closed list
	Given resolved list having 3 tasks and closed list having 3 tasks
	And closed column WIP is 8
	When promote task from resolved list to closed list
	Then resolved list having 2 tasks
	And closed list having 4 tasks

Scenario: Promote task from resolved list to full closed list
	Given resolved list having 4 tasks and closed list having 8 tasks
	And closed column WIP is 8
	When promote task from resolved list to closed list
	Then resolved list having 4 tasks
	And closed list having 8 tasks
	And WIP is full exception is raised

Scenario: Drop task from resolved list to not full todo list
	Given todo list having 4 tasks and resolved list having 4 tasks
	And todo column WIP is 5
	When drop task from resolved list
	Then todo list having 5 tasks
	And resolved list having 3 tasks

Scenario: Drop task from resolved list to full todo list
	Given todo list having 5 tasks and resolved list having 4 tasks
	And todo column WIP is 5
	When drop task from resolved list
	Then todo list having 5 tasks
	And resolved list having 4 tasks
	And WIP is full exception is raised

Scenario: Release full closed list
	Given closed list having 8 tasks
	And closed column WIP is 8
	When release
	Then closed list having 0 tasks

Scenario: Release not full closed list
	Given closed list having 3 tasks
	And closed column WIP is 8
	When release
	Then closed list having 0 tasks

Scenario: Release empty closed list
	Given closed list having 0 tasks
	And closed column WIP is 8
	When release
	Then closed list having 0 tasks
	And Empty release exception raised

Scenario: On empty todo list promote the most ICE score valued task from the non-empty backlog
	Given backlog task Chatbot impact is 7 ease is 2 confidence is 10
	And backlog task Dashboard impact is 6 ease is 2 confidence is 10
	And backlog task Mobile client impact is 7 ease is 5 confidence is 10
	And backlog task Cloud impact is 7 ease is 2 confidence is 2
	When promote last todo task to in work
	Then todo list having 1 tasks
	And todo list task ICE score is 350
	And todo list task name is Mobile client
	And backlog dont have Mobile client task
	And promotion message has been sent

Scenario: On empty todo list and empty backlog congratulate me with no tasks to process
	Given backlog having 0 tasks and todo list having 1 tasks
	When promote last todo task to in work
	Then Congratulate with no tasks to process

Scenario: On empty backlog and empty todo list and empty in work list and empty resolved list release and non-empty closed list and congratulate with no work to do
	Given backlog having 0 tasks and todo list having 0 tasks and in work list having 0 tasks and resolved list having 1 tasks and closed list having 5 tasks
	When promote task from resolved list to closed list
	Then Congratulate with no work to do