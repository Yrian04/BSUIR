from src.controller.commands.command import Command


class CommandException(Exception):
    def __init__(self, command: Command):
        self.command = command

    def __str__(self):
        return (f"Command {self.command.name} with arguments "
                f"{", ".join(self.command.args)} can't be executed")
