SELECT SUM(host.DepositAmount-guest.DepositAmount) AS SumDifference
FROM WizzardDeposits AS host
JOIN WizzardDeposits AS guest ON host.id+1=guest.id 