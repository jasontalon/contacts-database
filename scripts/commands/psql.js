const {exec} = require("../helpers");

const executeDbCommand = async (command) => {
    const container = "contacts-database-db-1",
        user = "postgres";

    let args = ["exec", container, "bash", "-c", `"psql -U ${user} --no-password -c \\"${command}\\""`];

    return await exec("docker", args);
};

module.exports = {
    args: [
        ["--command", "-c", "command to send"],
    ],
    exec: async ({command, c}) =>
        await executeDbCommand(command || c),
};
