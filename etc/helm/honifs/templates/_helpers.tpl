{{- define "honifs.hosts.httpapi" -}}
{{- print "https://" (.Values.global.hosts.httpapi | replace "[RELEASE_NAME]" .Release.Name) -}}
{{- end -}}
{{- define "honifs.hosts.angular" -}}
{{- print "https://" (.Values.global.hosts.angular | replace "[RELEASE_NAME]" .Release.Name) -}}
{{- end -}}
